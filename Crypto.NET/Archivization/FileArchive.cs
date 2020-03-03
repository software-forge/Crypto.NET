using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

using Crypto.NET.Encryption;
using Crypto.NET.Compression;

namespace Crypto.NET.Archivization
{
    public class FileArchive
    {
        public string FilePath { get; private set; }

        public EncryptionKey ArchiveKey { get; private set; }

        public bool IsCompressed { get; private set; }

        public bool IsOpen
        {
            get
            {
                return (Connection != null) && (Connection.State == ConnectionState.Open);
            }
        }

        public Hashtable IdFileNamePairs { get; set; }

        private string ConnectionString
        {
            get
            {
                if (FilePath.Equals(""))
                    return "";
                else
                    return string.Format("Data Source={0}; Version=3;", FilePath);
            }
        }
        private SQLiteConnection Connection { get; set; }

        // Konstruktor prywatny dla wymuszenia wzorca factory
        private FileArchive()
        {
            IdFileNamePairs = new Hashtable();
        }

        /*
            Pomocnicze metody prywatne 
        */

        // Zwraca ID pliku o podanej nazwie (-1 jeżeli takiego pliku nie ma)
        private int FileId(string name)
        {
            int id = -1;

            foreach (int i in IdFileNamePairs.Keys)
            {
                if (IdFileNamePairs[i].Equals(name))
                {
                    id = i;
                    break;
                }
            }

            return id;
        }

        // Zwraca prawdę, jeżeli przekazana nazwa pliku jest unikalna w archiwum
        private bool FileNameUnique(string fileName)
        {
            foreach (string value in IdFileNamePairs.Values)
                if (value.Equals(fileName))
                    return false;
            return true;
        }

        // Tworzy plik archiwum jako bazę SQLite z odpowiednimi tabelami i rekordem danych klucza i kompresji
        private void CreateArchiveFile()
        {
            if (ArchiveKey == null)
                throw new Exception("Nie zdefiniowano klucza szyfrowania");

            SQLiteConnection.CreateFile(FilePath);

            Connection = new SQLiteConnection(ConnectionString);
            Connection.Open();

            SQLiteCommand command = new SQLiteCommand(Connection);

            // Utworzenie tabeli ArchiveInfo
            command.CommandText = "CREATE TABLE ArchiveInfo" +
                "(" +
                    "password_salt BLOB NOT NULL, " +
                    "keycheckvalue BLOB NOT NULL, " +
                    "compression INTEGER NOT NULL" +
                ");";

            command.ExecuteNonQuery();

            int compression = 0;
            if (IsCompressed)
                compression = 1;

            // Wstawienie do tabeli EncryptionKey rekordu danych klucza
            command.CommandText = "INSERT INTO ArchiveInfo(password_salt, keycheckvalue, compression) VALUES" +
                "(" +
                    "@PasswordSalt, " +
                    "@KeyCheckValue, " +
                    "'" + Convert.ToString(compression) + "'" +
                ");";
            command.Parameters.Add(new SQLiteParameter("PasswordSalt", ArchiveKey.PasswordSalt));
            command.Parameters.Add(new SQLiteParameter("KeyCheckValue", ArchiveKey.KeyCheckValue));
            
            command.ExecuteNonQuery();

            // Utworzenie tabeli FileData
            command.CommandText = "CREATE TABLE FileData" +
                "(" +
                    "id INTEGER PRIMARY KEY, " +
                    "name_l INTEGER NOT NULL, " +
                    "name BLOB NOT NULL, " +
                    "content_l INTEGER NOT NULL, " +
                    "content BLOB NOT NULL, " +
                    "iv BLOB NOT NULL" +
                ");";

            command.ExecuteNonQuery();
        }

        // Wczytuje dane klucza szyfrowania zapisane w archiwum i wyprowadza klucz z podanym hasłem 
        private void SelectArchiveInfo()
        {
            Connection = new SQLiteConnection(ConnectionString);
            Connection.Open();

            SQLiteCommand command = new SQLiteCommand(Connection);

            command.CommandText = "SELECT * FROM ArchiveInfo;";

            SQLiteDataReader reader = command.ExecuteReader();

            byte[] salt = new byte[EncryptionKey.SaltLength];
            byte[] checkvalue = new byte[EncryptionKey.BlockLength];
            int compression = 0;

            while(reader.Read())
            {
                reader.GetBytes(0, 0, salt, 0, EncryptionKey.SaltLength);
                reader.GetBytes(1, 0, checkvalue, 0, EncryptionKey.BlockLength);
                compression = reader.GetInt32(2);
            }

            if (compression == 1)
                IsCompressed = true;
            else
                IsCompressed = false;

            ArchiveKey = EncryptionKey.Create(salt, checkvalue);
        }

        // Wyprowadza wartość klucza z podanego hasła
        private void DeriveKey(string password)
        {
            if(ArchiveKey != null)
                ArchiveKey.Derive(password);
        }

        // Wczytuje z bazy zaszyfrowane nazwy plików (razem z id) i odszyfrowuje je
        private void SelectPlaintextFileNames()
        {
            if (!IsOpen)
                throw new Exception("Archiwum nieotwarte");

            if (!ArchiveKey.IsDerived)
                throw new Exception("Klucz niewyprowadzony");

            SQLiteCommand command = new SQLiteCommand(Connection);

            command.CommandText = "SELECT id, name_l, length(name), name, iv FROM FileData;";

            SQLiteDataReader reader = command.ExecuteReader();

            if(reader.HasRows)
                IdFileNamePairs.Clear();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);

                int nameLength = reader.GetInt32(1);

                int nameBlobLength = reader.GetInt32(2);
                byte[] name_bytes = new byte[nameBlobLength];
                reader.GetBytes(3, 0, name_bytes, 0, nameBlobLength);

                byte[] iv = new byte[EncryptionKey.BlockLength];
                reader.GetBytes(4, 0, iv, 0, EncryptionKey.BlockLength);

                name_bytes = Encryptor.DecryptBytes(name_bytes, ArchiveKey.Value, iv);

                byte[] n = new byte[nameLength];
                for(int i = 0; i < nameLength; i++)
                    n[i] = name_bytes[i];

                string name = Encoding.ASCII.GetString(n);

                IdFileNamePairs.Add(id, name);
            }
        }

        /*
            Metody publiczne zwracające obiekt klasy wg. wzorca factory
        */

        // Otwiera istniejący pod wskazaną ścieżką plik archiwum
        public static FileArchive Open(string filepath, string password)
        {
            if (!File.Exists(filepath))
                throw new Exception("Plik pod wskazaną ścieżką nie istnieje!");

            FileArchive archive = new FileArchive();
            archive.FilePath = filepath;

            // Wyciągnięcie z archiwum informacji o kluczu i kompresji
            archive.SelectArchiveInfo();

            // Wyprowadzenie klucza na podstawie podanego hasła
            archive.DeriveKey(password);

            // Wyciągnięcie z archiwum listy nazw plików w formie jawnej
            archive.SelectPlaintextFileNames();

            return archive;
        }

        // Tworzy pod wskazaną ścieżką nowy plik archiwum i pozostawia go otwartym
        public static FileArchive Create(string filepath, string password, bool compression)
        {
            if (File.Exists(filepath))
                throw new Exception("Plik pod wskazaną ścieżką już istnieje");

            EncryptionKey key = EncryptionKey.Generate(password);

            FileArchive archive = new FileArchive();
            archive.FilePath = filepath;
            archive.ArchiveKey = key;
            archive.IsCompressed = compression;

            archive.CreateArchiveFile();

            return archive;
        }

        // Tworzy głęboką kopię wystąpienia (niezbędne dla przechowania backupu)
        public FileArchive Clone()
        {
            FileArchive copy = new FileArchive();
            copy.FilePath = FilePath;
            copy.ArchiveKey = ArchiveKey.Clone();
            copy.IsCompressed = IsCompressed;

            Hashtable idFileNamePairs = new Hashtable();
            foreach (int id in IdFileNamePairs.Keys)
                idFileNamePairs.Add(id, IdFileNamePairs[id]);
            copy.IdFileNamePairs = idFileNamePairs;

            copy.Connection = (SQLiteConnection) Connection.Clone();

            return copy;
        }

        /*
            Metody publiczne realizujące operacje na otwartym archiwum
        */

        // Zamyka otwarte archiwum 
        public void Close()
        {
            if(IsOpen)
            {
                Connection.Close();
                ArchiveKey.Reset();
                FilePath = "";
                IdFileNamePairs.Clear();
            }
        }

        // Archiwizuje wskazany po ścieżce plik
        public void ArchiveFile(string path)
        {
            if (!IsOpen)
                throw new Exception("Archiwum nieotwarte");

            if (!ArchiveKey.IsDerived)
                throw new Exception("Klucz niewyprowadzony");

            if (!File.Exists(path))
                throw new Exception("Plik pod wskazaną lokalizacją nie istnieje");

            FileData file = FileData.Create(path);

            string plaintextName = file.NameStr;

            if (!FileNameUnique(plaintextName))
                throw new FileNamingException(plaintextName);

            if (IsCompressed)
                FileCompressor.CompressFile(file);

            FileEncryptor.EncryptFile(file, ArchiveKey);

            SQLiteCommand command = new SQLiteCommand(Connection);

            command.CommandText = "INSERT INTO FileData(name_l, name, content_l, content, iv) VALUES" +
                "(" +
                    "'" + Convert.ToString(file.NameLength) + "', " +
                    "@Name, " +
                    "'" + Convert.ToString(file.ContentLength) +  "', " +
                    "@Content, " +
                    "@IV" +
                ")";
            command.Parameters.Add(new SQLiteParameter("Name", file.Name));
            command.Parameters.Add(new SQLiteParameter("Content", file.Content));
            command.Parameters.Add(new SQLiteParameter("IV", file.IV));

            command.ExecuteNonQuery();

            command.CommandText = "SELECT last_insert_rowid();";
            long lastRowId = (long) command.ExecuteScalar();

            int fileId = (int) lastRowId;

            // Przechowanie pary id_pliku-nazwa_pliku
            IdFileNamePairs.Add(fileId, plaintextName);
        }

        // Wypakowuje z archiwum wskazany po identyfikatorze plik do wskazanego po ścieżce katalogu
        public void Extract(int id, string destPath)
        {
            if (!IsOpen)
                throw new Exception("Archiwum nieotwarte");

            if (!ArchiveKey.IsDerived)
                throw new Exception("Klucz niewyprowadzony");

            SQLiteCommand command = new SQLiteCommand(Connection);

            command.CommandText = "SELECT name_l, length(name), name, content_l, length(content), content, iv FROM FileData WHERE id='" + Convert.ToString(id) + "';";

            SQLiteDataReader reader = command.ExecuteReader();

            FileData file = null;

            while (reader.Read())
            {
                int nameLength = reader.GetInt32(0);

                int nameBlobLength = reader.GetInt32(1);
                byte[] fileName = new byte[nameBlobLength];
                reader.GetBytes(2, 0, fileName, 0, nameBlobLength);

                int contentLength = reader.GetInt32(3);

                int contentBlobLength = reader.GetInt32(4);
                byte[] content = new byte[contentBlobLength];
                reader.GetBytes(5, 0, content, 0, contentBlobLength);

                byte[] iv = new byte[EncryptionKey.BlockLength];
                reader.GetBytes(6, 0, iv, 0, EncryptionKey.BlockLength);

                file = FileData.Create(nameLength, fileName, contentLength, content, iv);
            }

            if (file != null)
            {
                FileEncryptor.DecryptFile(file, ArchiveKey);

                if (IsCompressed)
                    FileCompressor.DecompressFile(file);

                File.WriteAllBytes(Path.Combine(destPath, file.NameStr), file.Content);
            }
            else
            {
                throw new Exception(string.Format("Nie udało się odczytać danych pliku o id={0}", id));
            }
        }

        // Wypakowuje z archiwum wskazany po nazwie plik do wskazanego po ścieżce katalogu
        public void Extract(string name, string destPath)
        {
            int fileId = FileId(name);
            
            if(fileId == -1)
                throw new Exception("Brak w archiwum pliku o podanej nazwie");

            Extract(fileId, destPath);
        }

        // Wypakowuje wszystkie pliki z archiwum do wskazanego po ścieżce katalogu
        public void ExtractAll(string destPath)
        {
            foreach(int id in IdFileNamePairs.Keys)
                Extract(id, destPath);
        }

        // Usuwa z archiwum wskazany po identyfikatorze plik
        public void Delete(int id)
        {
            if (!IsOpen)
                throw new Exception("Archiwum nieotwarte");

            if (!ArchiveKey.IsDerived)
                throw new Exception("Klucz niewyprowadzony");

            SQLiteCommand command = new SQLiteCommand(Connection);

            command.CommandText = "DELETE FROM FileData WHERE id='" + Convert.ToString(id) +"';";

            command.ExecuteNonQuery();

            IdFileNamePairs.Remove(id);
        }

        // Usuwa z archiwum wskazany po nazwie plik
        public void Delete(string name)
        {
            int fileId = FileId(name);
            
            if (fileId == -1)
                throw new Exception("Brak w archiwum pliku o podanej nazwie");

            Delete(fileId);
        }

        // Usuwa wszystkie pliki z archiwum
        public void DeleteAll()
        {
            SQLiteCommand command = new SQLiteCommand(Connection);

            command.CommandText = "DELETE FROM FileData;";

            command.ExecuteNonQuery();

            IdFileNamePairs.Clear();
        }

        // Zwraca listę nazw plików zapisanych w archiwum
        public List<string> FileList
        {
            get
            {
                List<string> filenames = new List<string>();
                foreach (string s in IdFileNamePairs.Values)
                    filenames.Add(s);
                return filenames;
            }
        }
    }
}

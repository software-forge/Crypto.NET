using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

using Crypto.NET.Encryption;

namespace Crypto.NET.Archivization
{
    public class FileData
    {
        public byte[] Name { get; set; }
        public int NameLength { get; set; }

        public string NameStr
        {
            get
            {
                if (!IsEncrypted)
                {
                    byte[] b = new byte[NameLength];
                    for (int i = 0; i < NameLength; i++)
                        b[i] = Name[i];

                    return Encoding.ASCII.GetString(b);
                }
                else
                    return "";
            }
        }

        public byte[] Content { get; set; }
        public int ContentLength { get; set; }

        public bool IsEncrypted { get; set; }

        public byte[] IV { get; private set; }

        // Konstruktor prywatny dla wymuszenia wzorca factory
        private FileData() {  }

        // Tworzy nowy obiekt wczytując plik jawny z dysku
        public static FileData Create(string filePath)
        {
            FileData fileData = new FileData();
            fileData.Name = Encoding.ASCII.GetBytes(Path.GetFileName(filePath));
            fileData.NameLength = Path.GetFileName(filePath).Length;

            // Wczytanie zawartości pliku
            fileData.Content = File.ReadAllBytes(filePath);
            fileData.IsEncrypted = false;

            fileData.ContentLength = fileData.Content.Length;

            // Wygenerowanie wektora inicjującego
            fileData.IV = new byte[EncryptionKey.BlockLength];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(fileData.IV);
            }

            return fileData;
        }

        // Tworzy nowy obiekt po wczytaniu danych zaszyfrowanego pliku z bazy
        public static FileData Create(int nameL, byte[] name,  int contentL, byte[] content, byte[] iv)
        {
            FileData fileData = new FileData();
            fileData.NameLength = nameL;
            fileData.Name = name;
            fileData.ContentLength = contentL;
            fileData.Content = content;
            fileData.IsEncrypted = true;

            fileData.IV = iv;

            return fileData;
        }
    }
}

using System;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Crypto.NET.Encryption;

namespace Crypto.NET.Archivization
{
    public class FileData
    {
        // Metoda set musi być publiczna dla metod klasy FileEncryptor
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
        public int ContentLength { get; private set; }
        
        public bool IsEncrypted { get; set; }

        public byte[] IV { get; private set; }

        private FileData() {  }

        // Tworzy nowy obiekt wczytując plik jawny z dysku
        public static FileData Create(string filepath)
        {
            FileData fileData = new FileData();
            fileData.Name = Encoding.ASCII.GetBytes(Path.GetFileName(filepath));
            fileData.NameLength = Path.GetFileName(filepath).Length;

            // Wczytanie zawartości pliku
            fileData.Content = File.ReadAllBytes(filepath);
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
        public static FileData Create(int name_l, byte[] name,  int content_l, byte[] content, byte[] iv)
        {
            FileData fileData = new FileData();
            fileData.NameLength = name_l;
            fileData.Name = name;
            fileData.ContentLength = content_l;
            fileData.Content = content;
            fileData.IsEncrypted = true;
            fileData.IV = iv;

            return fileData;
        }

        public static FileData CreateDirectory(string path)
        {
            FileData fileData = new FileData();
            fileData.Name = Encoding.ASCII.GetBytes(path);
            fileData.ContentLength = -1;
            fileData.IsEncrypted = false;

            // Wygenerowanie wektora inicjującego
            fileData.IV = new byte[EncryptionKey.BlockLength];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(fileData.IV);
            }

            return fileData;
        }
        
    }
}

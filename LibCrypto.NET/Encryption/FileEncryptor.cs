using System;

using LibCrypto.NET.Archivization;

namespace LibCrypto.NET.Encryption
{
    public class FileEncryptor
    {
        public static void EncryptFile(FileData file, EncryptionKey key)
        {
            if (!key.IsDerived)
                throw new Exception("Klucz nie został wyprowadzony");

            if(!file.IsEncrypted)
            {
                file.Content = Encryptor.EncryptBytes(file.Content, key.Value, file.IV);
                file.Name = Encryptor.EncryptBytes(file.Name, key.Value, file.IV);
                file.IsEncrypted = true;
            }
            else
            {
                throw new Exception("Plik jest już zaszyfrowany");
            }
        }

        public static void DecryptFile(FileData file, EncryptionKey key)
        {
            if (!key.IsDerived)
                throw new Exception("Klucz nie został wyprowadzony");

            if (file.IsEncrypted)
            {
                file.Content = Encryptor.DecryptBytes(file.Content, key.Value, file.IV);
                file.Name = Encryptor.DecryptBytes(file.Name, key.Value, file.IV);
                file.IsEncrypted = false;
            }
            else
            {
                throw new Exception("Plik jest już odszyfrowany");
            }
        }
    }
}

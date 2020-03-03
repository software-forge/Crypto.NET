using System.Security.Cryptography;
using System.Text;
using System;

namespace Crypto.NET.Encryption
{
    public class EncryptionKey
    {
        public byte[] PasswordSalt { get; private set; }
        public byte[] KeyCheckValue { get; private set; }

        public bool IsDerived { get; private set; }
        public byte[] Value { get; private set; }

        public static int Iterations = 5000; // Liczba iteracji funkcji PBKDF2

        public static int SaltLength = 16;  // Długość soli kryptograficznej w bajtach 16B = 128b

        public static int BlockLength = 16; // Długość bloku szyfru AES 16B = 128b
        public static int KeyLength = 32;   // Długość klucza szyfrowania 32B = 256b

        // Konstruktor prywatny dla wymuszenia wzorca factory
        private EncryptionKey(byte[] salt, byte[] checkvalue)
        {
            PasswordSalt = salt;
            KeyCheckValue = checkvalue;

            IsDerived = false;
        }

        /*
            Metody publiczne zwracające obiekt klasy wg. wzorca factory 
        */

        // Generuje nowy klucz na podstawie hasła
        public static EncryptionKey Generate(string password)
        {
            byte[] salt = new byte[SaltLength];

            // Wygenerowanie soli
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);

            // Wyprowadzenie wartości klucza
            byte[] passwordBytes = Encoding.ASCII.GetBytes(password);
            Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(passwordBytes, salt, Iterations, HashAlgorithmName.SHA256);
            byte[] value = rfc2898.GetBytes(KeyLength);

            // Obliczenie checkvalue
            byte[] checkvalue = Encryptor.EncryptBytes(new byte[BlockLength], value, new byte[BlockLength]);

            EncryptionKey key = new EncryptionKey(salt, checkvalue);
            key.Derive(password);

            return key;
        }

        // Zwraca nowy obiekt klasy EncryptionKey na podstawie danych klucza wczytanych z archiwum 
        public static EncryptionKey Create(byte[] salt, byte[] checkvalue)
        {
            return new EncryptionKey(salt, checkvalue);
        }

        // Tworzy głęboką kopię wystąpienia (niezbędne dla przechowania backupu)
        public EncryptionKey Clone()
        {
            EncryptionKey copy = new EncryptionKey(PasswordSalt, KeyCheckValue);

            if (IsDerived)
            {
                copy.IsDerived = true;
                copy.Value = Value;
            }

            return copy;
        }

        /*
            Metody publiczne
        */

        // Wyprowadza wartość klucza na podstawie hasła
        public void Derive(string password)
        {
            byte[] passwordBytes = Encoding.ASCII.GetBytes(password);
            Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(passwordBytes, PasswordSalt, Iterations, HashAlgorithmName.SHA256);
            Value = rfc2898.GetBytes(KeyLength);

            // Zweryfikowanie checkvalue
            byte[] checkvalue = Encryptor.EncryptBytes(new byte[BlockLength], Value, new byte[BlockLength]);

            for(int i = 0; i < BlockLength; i++)
            {
                if(checkvalue[i] != KeyCheckValue[i])
                {
                    Value = new byte[KeyLength];
                    throw new KeyDerivationException(KeyCheckValue, checkvalue);
                }
            }

            IsDerived = true;
        }

        // Resetuje klucz, jeżeli uprzednio został on wyprowadzony
        public void Reset()
        {
            if(IsDerived)
            {
                Value = new byte[KeyLength];
                IsDerived = false;
            }
        }
    }
}

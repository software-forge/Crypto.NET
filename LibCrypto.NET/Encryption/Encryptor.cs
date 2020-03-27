using System.IO;
using System.Security.Cryptography;

namespace LibCrypto.NET.Encryption
{
    public static class Encryptor
    {
        public static byte[] EncryptBytes(byte[] input, byte[] key, byte[] iv)
        {
            byte[] output = new byte[input.Length];

            using (AesManaged aes = new AesManaged())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);
                
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(input, 0, input.Length);
                    }

                    output = memoryStream.ToArray();
                }
            }

            return output;
        }

        public static byte[] DecryptBytes(byte[] input, byte[] key, byte[] iv)
        {
            byte[] output = new byte[input.Length];

            using (AesManaged aes = new AesManaged())
            {
                ICryptoTransform decryptor = aes.CreateDecryptor(key, iv);

                using (MemoryStream memoryStream = new MemoryStream(input))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        cryptoStream.Read(output, 0, output.Length);
                    }
                }
            }

            return output;
        }
    }
}

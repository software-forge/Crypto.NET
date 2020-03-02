using System;
using System.IO;
using System.IO.Compression;

namespace Crypto.NET.Compression
{
    public static class Compressor
    {
        public static byte[] CompressBytes(byte[] input)
        {
            if (input == null)
                throw new ArgumentNullException("Dane wejściowe kompresji nie mogą być null");

            byte[] output;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Compress))
                {
                    deflateStream.Write(input, 0, input.Length);
                }

                output = memoryStream.ToArray();
            }

            return output;
        }

        public static byte[] DecompressBytes(byte[] input, int outputSize)
        {
            if (input == null)
                throw new ArgumentNullException("Dane wejściowe dekompresji nie mogą być null");

            byte[] output = new byte[outputSize];

            using (MemoryStream memoryStream = new MemoryStream(input))
            {
                using (DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Decompress))
                {
                    deflateStream.Read(output, 0, outputSize);
                }
            }

            return output;
        }
    }
}

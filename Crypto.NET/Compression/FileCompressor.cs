using Crypto.NET.Archivization;

namespace Crypto.NET.Compression
{
    public static class FileCompressor
    {
        public static void CompressFile(FileData file)
        {
            file.Content = Compressor.CompressBytes(file.Content);
        }

        public static void DecompressFile(FileData file)
        {
            file.Content = Compressor.DecompressBytes(file.Content, file.ContentLength);
        }
    }
}

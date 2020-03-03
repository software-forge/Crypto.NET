using System;

namespace Crypto.NET.Archivization
{
    public class FileNamingException : Exception
    {
        public string FileName { get; private set; }

        public FileNamingException(string fileName) : base(string.Format("Plik o nazwie {0} już istnieje w archiwum.", fileName))
        {
            FileName = fileName;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCrypto.NET.Encryption
{
    public class KeyDerivationException : Exception
    {
        public byte[] ExpectedKeyCheckValue { get; private set; }
        public byte[] CalculatedKeyCheckValue { get; private set; }

        public KeyDerivationException(byte[] expectedKeyCheckValue, byte[] calculatedKeyCheckValue) : base("Nie udało się wyprowadzić klucza szyfrowania z użyciem podanego hasła.")
        {
            ExpectedKeyCheckValue = expectedKeyCheckValue;
            CalculatedKeyCheckValue = calculatedKeyCheckValue;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.NET.Encryption
{
    public class KeyDerivationException : Exception
    {
        public byte[] ExpectedKeyCheckValue { get; private set; }
        public byte[] CalculatedKeyCheckValue { get; private set; }

        public override string Message
        {
            get
            {
                return string.Format("Nie udało się wyprowadzić klucza z użyciem podanego hasła");
            }
        }

        public KeyDerivationException(byte[] expectedKeyCheckValue, byte[] calculatedKeyCheckValue) : base()
        {
            ExpectedKeyCheckValue = expectedKeyCheckValue;
            CalculatedKeyCheckValue = calculatedKeyCheckValue;
        }
    }
}

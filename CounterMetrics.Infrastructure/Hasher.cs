using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CounterMetrics.Infrastructure
{
    class Hasher : IHasher
    {
        private readonly MD5 engine = MD5.Create();

        public string Hash(string source)
        {
            //throw new NotImplementedException();
            byte[] data = engine.ComputeHash(Encoding.UTF8.GetBytes(source));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder stringBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                stringBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return stringBuilder.ToString();
        }
    }
}

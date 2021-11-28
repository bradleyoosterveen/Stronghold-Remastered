using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class Hash
    {
        public static string Create(string str)
        {
            return GetHash(SHA256.Create(), str);
        }
        public static bool Verify(string input, string hash)
        {
            var hashOfInput = Hash.GetHash(SHA256.Create(), input);

            StringComparer comparer = StringComparer.Ordinal;

            return comparer.Compare(hashOfInput, hash) == 0;
        }
        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}

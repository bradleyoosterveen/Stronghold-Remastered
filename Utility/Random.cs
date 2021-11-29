using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class Randomizer
    {
        private static Random _random = new Random();
        public static string String(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            return new string(Enumerable.Repeat(chars, length).Select(s => s[Randomizer._random.Next(s.Length)]).ToArray());
        }
    }
}

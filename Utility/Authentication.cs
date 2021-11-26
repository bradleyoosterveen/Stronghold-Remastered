using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class Authentication
    {
        public static string Username { get; private set; }

        public static void New(string username)
        {
            Authentication.Username = username;
        }
    }
}

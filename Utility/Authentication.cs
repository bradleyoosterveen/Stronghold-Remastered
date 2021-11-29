using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class Authentication
    {
        public static User User { get; private set; }

        public static void New(User user)
        {
            Authentication.User = user;
        }

        public static void Dispose()
        {
            Authentication.User = null;
        }
    }
}

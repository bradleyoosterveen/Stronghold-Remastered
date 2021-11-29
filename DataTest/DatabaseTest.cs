using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Model;
using NUnit.Framework;
using SqlKata.Execution;

namespace DataTest
{
    [TestFixture]
    class DatabaseTest
    {
        [SetUp]
        public void SetUp()
        {
            DotNetEnv.Env.TraversePath().Load();
            Database.Initialize();
        }

        [Test]
        public void Test_GetUser_NoUser()
        {
            IEnumerable<User> users = Database.QueryFactory.Query("User").Where("Username", "=", "Test").Get<User>();

            User user = users.First();

            Console.WriteLine(user.Username);
        }
    }
}

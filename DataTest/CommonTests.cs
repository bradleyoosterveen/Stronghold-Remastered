using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using Data;
using Model;
using NUnit.Framework;
using SqlKata.Execution;
using Utility;

namespace DataTest
{
    [TestFixture]
    class CommonTests
    {
        private User _user;
        [SetUp]
        public void SetUp()
        {
            DotNetEnv.Env.TraversePath().Load();
            Database.Initialize();
            
            this._user =  Database.QueryFactory.Query("User").Where("Username", "admin").Get<User>().First();
            Authentication.New(this._user);
        }

        [Test]
        public void Test_GetUser_NoUser()
        {
            IEnumerable<User> users = Database.QueryFactory.Query("User").Where("Username", "=", "Test").Get<User>();

            User user = users.First();

            Console.WriteLine(user.Username);
        }

        [Test]
        public void Test_LandmarkController_InsertLandmark()
        {
            LandmarkController landmarkController = new LandmarkController();

            Request request = new Request();

            request.AddData("dimension_id", 1);
            request.AddData("description", "World description...");
            request.AddData("x", 115);
            request.AddData("y", 65);
            request.AddData("z", 452);

            Feedback feedback = landmarkController.InsertLandmark(request);

            if (feedback.MessageType == Feedback.Type.Success)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}

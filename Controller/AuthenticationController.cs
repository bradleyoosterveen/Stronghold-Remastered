using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using Data;
using Model;
using SqlKata.Execution;

namespace Controller
{
    public class AuthenticationController : Controller
    {
        public Feedback SignIn(Request request)
        {
            string username = (string)request.GetData("username");
            string securityToken = (string)request.GetData("securitytoken");

            if (username is "" or null)
                return new Feedback(Feedback.Type.Error, "Username can not be empty.");

            if (securityToken is "" or null)
                return new Feedback(Feedback.Type.Error, "Security token can not be empty.");

            IEnumerable<User> users = Database.QueryFactory.Query("User").Where("Username", "=", username).Get<User>();

            if (!users.Any())
                return new Feedback(Feedback.Type.Error, "You have entered the wrong credentials.");

            User user = users.First();

            if (user.SecurityToken != securityToken)
                return new Feedback(Feedback.Type.Error, "You have entered the wrong credentials.");

            Authentication.New(user);

            return new Feedback(Feedback.Type.Success, "You are now signed in.");
        }

        public Feedback SignOut()
        {
            if (Authentication.User == null)
                return new Feedback(Feedback.Type.Error, "How..?");

            Authentication.Dispose();

            return new Feedback(Feedback.Type.Success, "You are now signed out.");
        }
    }
}

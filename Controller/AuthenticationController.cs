using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

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

            Authentication.New(username);

            return null;
        }
    }
}

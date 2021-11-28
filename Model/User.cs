using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User : BaseModel
    {
        public string Username { get; set; }
        public string SecurityToken { get; set; }
        public Role Role { get; set; }

        public User(string username, string securityToken, Role role)
        {
            this.Username = username;
            this.SecurityToken = securityToken;
            this.Role = role;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User : BaseModel
    {
        public static readonly string Table = "User";
        public int ID { get; set; }
        public string Username { get; set; }
        public string SecurityToken { get; set; }
        public Role Role { get; set; }

        public User(int id, string username, string securityToken, Role role)
        {
            this.ID = id;
            this.Username = username;
            this.SecurityToken = securityToken;
            this.Role = role;
        }
    }
}

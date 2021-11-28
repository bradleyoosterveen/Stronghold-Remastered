using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Role : BaseModel
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public Role(int id, string description)
        {
            this.ID = id;
            this.Description = description;
        }
    }
}

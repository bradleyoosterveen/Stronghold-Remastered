using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Dimension
    {
        public static readonly string Table = "Dimension";
        public int ID { get; set; }
        public string Description { get; set; }

        public Dimension() { }
        public Dimension(int id, string description)
        {
            this.ID = id;
            this.Description = description;
        }
    }
}

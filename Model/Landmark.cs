using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Landmark
    {
        public static readonly string Table = "Landmark";
        public int ID { get; set; }
        public string Description { get; set; }
        public int Dimension_ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int Owner_ID { get; set; }

        public Landmark() { }
        public Landmark(int id, string description, int dimension_id, int x, int y, int z, int owner_id)
        {
            this.ID = id;
            this.Description = description;
            this.Dimension_ID = dimension_id;
            this.X = x;
            this.Y = y;
            this.X = x;
            this.Owner_ID = owner_id;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Model;
using SqlKata.Execution;

namespace Controller
{
    public class DashboardController : Controller
    {
        public List<Landmark> GetLandmarks()
        {
            IEnumerable<Landmark> landmarks = Database.QueryFactory.Query(Landmark.Table).Get<Landmark>();

            foreach (Landmark landmark in landmarks)
            {
                landmark.Owner = Database.QueryFactory.Query(User.Table).Where("ID", landmark.Owner_ID).Get<User>().First();
                landmark.Dimension = Database.QueryFactory.Query(Dimension.Table).Where("ID", landmark.Dimension_ID).Get<Dimension>().First();
            }

            return landmarks.ToList();
        }
    }
}

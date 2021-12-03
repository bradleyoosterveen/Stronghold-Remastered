using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Model;
using SqlKata.Execution;
using Utility;

namespace Controller
{
    public class LandmarkCardController : Controller
    {
        public Feedback DeleteLandmark(int id)
        {
            _ = Database.QueryFactory.Query(Landmark.Table).Where("ID", id).Delete();

            return new Feedback(Feedback.Type.Success, "Landmark deleted.");
        }
    }
}

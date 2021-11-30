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
    public class LandmarkController : Controller
    {
        public Feedback InsertLandmark(Request request)
        {
            if (Authentication.User == null)
                return new Feedback(Feedback.Type.Error, "You are not authorized.");

            IEnumerable<Dimension> dimensions = Database.QueryFactory.Query(Dimension.Table).Where("ID", request.GetData("dimension_id")).Get<Dimension>();

            if (!dimensions.Any())
                return new Feedback(Feedback.Type.Error, "No valid dimension found.");

            Dimension dimension = dimensions.First();

            _ = Database.QueryFactory.Query(Landmark.Table).Insert(new
            {
                Description = request.GetData("description"),
                Dimension_ID = dimension.ID,
                X = request.GetData("x"),
                y = request.GetData("y"),
                z = request.GetData("z"),
                Owner_ID = Authentication.User.ID
            });

            return new Feedback(Feedback.Type.Success, "Landmark created.");
        }
    }
}

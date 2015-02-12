using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Footinder.Models;

namespace Footinder.Controllers
{
    public class RestaurantsController : Controller
    {
        //
        // GET: /Restaurants/

        public ActionResult Index()
        {
            var data = new Restaurant[]
            {
                new Restaurant { Name = "פטרוזיליה", Id = Guid.NewGuid().ToString()},
                new Restaurant { Name = "רוסטיקו", Id = Guid.NewGuid().ToString()},
                new Restaurant { Name = "סאלם בומביי", Id = Guid.NewGuid().ToString()},
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}

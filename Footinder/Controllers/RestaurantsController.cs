using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Footinder.DataAccess;
using Footinder.Models;

namespace Footinder.Controllers
{
    public class RestaurantsController : Controller
    {
        private RestaurantsRepository mRestaurantRepository;

        public RestaurantsController()
        {
            mRestaurantRepository = new RestaurantsRepository();
        }

        public ActionResult Index()
        {
            return Json(mRestaurantRepository.ListRestaurants(), JsonRequestBehavior.AllowGet);
        }
    }
}

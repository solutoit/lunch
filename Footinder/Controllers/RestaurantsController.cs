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
        private RepositoryFactory mRepositoryFactory;

        public RestaurantsController()
        {
            mRepositoryFactory = new RepositoryFactory();
        }

        public ActionResult Index()
        {
            var restaurants = mRepositoryFactory.Create<Restaurant>().List();
            return Json(restaurants, JsonRequestBehavior.AllowGet);
        }
    }
}

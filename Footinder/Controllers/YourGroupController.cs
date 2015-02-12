using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Footinder.BuisnessLogic;
using Footinder.DataAccess;
using Footinder.Models;

namespace Footinder.Controllers
{
    public class YourGroupController : Controller
    {
        private readonly RepositoryFactory mRepositoryFactory;
        private readonly LunchGroupsDecider mLunchGroupsDecider;

        public YourGroupController()
        {
            mLunchGroupsDecider = new LunchGroupsDecider();
            mRepositoryFactory = new RepositoryFactory();
        }

        public ActionResult Index()
        {
            var votes = mRepositoryFactory.Create<Vote>().List();

            var now = DateTime.Now;
            var votesForToday = votes.Where(x => x.Date.Date == now.Date && x.Decision && x.User != null);

            var restuartntGroup = mLunchGroupsDecider.Decide(votesForToday);

            var currentUser = (User)Session["User"];

            var userRestaurntGrop = restuartntGroup.First(x => x.Value.Any(y =>y.Name == currentUser.Name));
            userRestaurntGrop.Value.Remove(currentUser);

            var yourGroupModel = new YourGroupModel
            {
                Restaurant = userRestaurntGrop.Key,
                GroupUsers = userRestaurntGrop.Value.Where(x=>x !=null).ToList(),
                CurrentUser = currentUser,
                LaunchTime = new DateTime(now.Year, now.Month, now.Day, 12, 0, 0)
            };

            return View(yourGroupModel);
        }

    }
}

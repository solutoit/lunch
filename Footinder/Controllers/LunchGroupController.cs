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
    public class LunchGroupController : Controller
    {
        private readonly RepositoryFactory mRepositoryFactory;
        private readonly LunchGroupsDecider mLunchGroupsDecider;

        public LunchGroupController()
        {
            mLunchGroupsDecider = new LunchGroupsDecider();
            mRepositoryFactory = new RepositoryFactory();
        }

        public ActionResult Index()
        {
            var votes = mRepositoryFactory.Create<Vote>().List();

            var now = DateTime.Now;
            var votesForToday = votes.Where(x => x.Date.Date == now.Date && x.Decision);

            var restuartntGroup = mLunchGroupsDecider.Decide(votesForToday);

            var currentUser = new User();

            var userRestaurntGrop = restuartntGroup.First(x => x.Value.Contains(currentUser));
            userRestaurntGrop.Value.Remove(currentUser);

            var lunchGroupModel = new LunchGroupModel
            {
                Restaurant = userRestaurntGrop.Key,
                GroupUsers = userRestaurntGrop.Value,
                CurrentUser = currentUser,
                LaunchTime = new DateTime(now.Year, now.Month, now.Day, 12, 0, 0)
            };

            return View(lunchGroupModel);
        }

    }
}

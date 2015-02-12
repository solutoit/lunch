using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Providers.Entities;
using Footinder.DataAccess;
using Footinder.Models;
using User = Footinder.Models.User;

namespace Footinder.Controllers
{
    public class VoteController : Controller
    {
        private RepositoryFactory mRepositoryFactory;

        public VoteController()
        {
            mRepositoryFactory = new RepositoryFactory();
        }

        [System.Web.Http.HttpPost]
        public void Index(string id, bool vote)
        {
            var voteItem = new Vote
            {
                Date = DateTime.UtcNow,
                Decision = vote,
                Restaurant = mRepositoryFactory.Create<Restaurant>().GetOne(id),
                User = Session["User"] as User,
            };

            var voteRepository = mRepositoryFactory.Create<Vote>();
            voteRepository.Insert(voteItem);
        }
    }
}

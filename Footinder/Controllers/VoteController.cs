using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Footinder.DataAccess;
using Footinder.Models;

namespace Footinder.Controllers
{
    public class VoteController : ApiController
    {
        private RepositoryFactory mRepositoryFactory;

        public VoteController()
        {
            mRepositoryFactory = new RepositoryFactory();
        }

        public void Post(string id, bool vote)
        {
            var voteItem = new Vote
            {
                Date = DateTime.UtcNow.ToString("yyyyMMdd"),
                Decision = vote,
                Restaurant = mRepositoryFactory.Create<Restaurant>().GetOne(id),
                User = new User { Name = User.Identity.Name },
            };

            var voteRepository = mRepositoryFactory.Create<Vote>();
            voteRepository.Insert(voteItem);
        }
    }
}

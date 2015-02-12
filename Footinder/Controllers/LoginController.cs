﻿using System.Web.Mvc;
using Footinder.DataAccess;
using User = Footinder.Models.User;

namespace Footinder.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        private readonly RepositoryFactory mRepositoryFactory;

        public LoginController()
        {
            mRepositoryFactory = new RepositoryFactory();
        }

        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Http.HttpPost]
        public RedirectResult DoLogin(string name)
        {
            name = name.ToLower();
            var userRepo = mRepositoryFactory.Create<User>();
            var user = userRepo.GetOne(u => u.Name ,name);
            if (user == null)
            {
                userRepo.Insert(new User()
                {
                    Name = name
                });
            }

            Session["User"] = user;


            return Redirect("/Decisions");
        }
    }
}

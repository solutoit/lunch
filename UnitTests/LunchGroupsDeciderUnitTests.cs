﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using Footinder.BuisnessLogic;
using Footinder.Models;
using MongoDB.Bson;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class LunchGroupsDeciderUnitTests
    {
        private LunchGroupsDecider mLunchGroupsDecider;
        private Restaurant FirstRestaurant;
        private Restaurant SecondRestaurant;
        private Restaurant ThirdRestaurant;
   

        [SetUp]
        public void SetUp()
        {
            mLunchGroupsDecider = new LunchGroupsDecider();
            FirstRestaurant = new Restaurant { Id = "518cbb1389da79d3a25453f0" };
            SecondRestaurant = new Restaurant { Id = "518cbb1389da79d3a25453f9" };
            ThirdRestaurant = new Restaurant { Id = "518cbb1389da79d3a25453f1" };
        }

        [Test]
        public void LunchGroupsDecider_4UserForOneRestaruant_OneLanuchGroupd()
        {
            var users = CreateUsers(4);
            IEnumerable<Vote> votes = CreatVotesFor(FirstRestaurant, users.ToArray());

            mLunchGroupsDecider.Decide(votes);
        }

        private IEnumerable<Vote> CreatVotesFor(Restaurant restaurant, params User[] users)
        {
            if (users == null) return new List<Vote>();

            return users.Select(user => new Vote
            {
                Restaurant = restaurant, User = user, Decision = true, Date = DateTime.Now
            }).ToList();
        }

        private List<User> CreateUsers(int numOfUsers)
        {
            var users = new List<User>();
            for (int i = 0; i < numOfUsers; i++)
            {
                users.Add(new User
                {
                    Name = i.ToString(),
                    UserId = i,
                    UserName = i.ToString()
                });
            }
            return users;
        }
    }
}

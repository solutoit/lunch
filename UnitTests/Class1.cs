using System;
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
            FirstRestaurant = new Restaurant {Id = new ObjectId()};
            SecondRestaurant = new Restaurant {Id = new ObjectId()};
            ThirdRestaurant = new Restaurant {Id = new ObjectId()};
        }

        [Test]
        public void LunchGroupsDecider_4UserForOneRestaruant_OneLanuchGroupd()
        {
            //Arrange
            var lunchGroupsDecider = mLunchGroupsDecider;
            var votes = new List<Vote>();
            Console.WriteLine(FirstRestaurant.Id);
            Console.WriteLine(SecondRestaurant.Id);
            //Act
            //Assert
        }
    }
}

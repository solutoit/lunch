using System.Collections.Generic;
using System.Configuration;
using Footinder.Models;
using MongoDB.Driver;

namespace Footinder.DataAccess
{
    public class RestaurantsRepository
    {
        public IEnumerable<Restaurant> ListRestaurants()
        {
            var db = GetDb();
            var restaurantsColection = db.GetCollection<Restaurant>("restaurants");
            return restaurantsColection.FindAll();
        }

        private MongoDatabase GetDb()
        {
            var client = new MongoClient(ConfigurationManager.ConnectionStrings["mongodb"].ConnectionString);
            var server = client.GetServer();
            var db = server.GetDatabase("lunch");
            return db;
        }
    }

    public interface IRestaurantsRepository
    {
        IEnumerable<Restaurant> ListRestaurants();
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace Footinder.DataAccess
{
    public class Repository<T>
    {
        private MongoCollection<T> mCollection;

        public Repository(MongoCollection<T> mongoCollection)
        {
            mCollection = mongoCollection;
        }

        public IEnumerable<T> List()
        {
            return mCollection.FindAll();
        }
    }

    public class RepositoryFactory
    {
        public Repository<T> Create<T>()
        {
            var attribute = typeof (T).GetCustomAttributes(typeof(CollectionAttribute), false).FirstOrDefault() as CollectionAttribute;
            var database = GetDb();
            return new Repository<T>(database.GetCollection<T>(attribute.CollectionName));
        }

        private MongoDatabase GetDb()
        {
            var client = new MongoClient(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            var server = client.GetServer();
            var db = server.GetDatabase("lunch");
            return db;
        }

    }

    public class CollectionAttribute : Attribute
    {
        public string CollectionName { get; set; }

        public CollectionAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }
    }
}
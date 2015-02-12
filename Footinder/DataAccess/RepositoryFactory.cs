using System.Configuration;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace Footinder.DataAccess
{
    public class RepositoryFactory
    {
        public Repository<T> Create<T>() where T : IMongoIdentifiable
        {
            var attribute = typeof (T).GetCustomAttributes(typeof(CollectionAttribute), false).FirstOrDefault() as CollectionAttribute;
            var database = GetDb();
            return new Repository<T>(database.GetCollection<T>(attribute.CollectionName));
        }

        private MongoDatabase GetDb()
        {
            var client = new MongoClient(ConfigurationManager.ConnectionStrings["mongodb"].ConnectionString);
            var server = client.GetServer();
            var db = server.GetDatabase("lunch");
            return db;
        }
    }
}
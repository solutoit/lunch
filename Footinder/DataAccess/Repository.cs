using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Footinder.DataAccess
{
    public class Repository<T> where T : IIdentifiable
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

        public void Insert(T item)
        {
            mCollection.Insert(item);
        }

        public T GetOne(string id)
        {
            var query = Query<T>.EQ(e => e.Id, new ObjectId(id));
            return mCollection.Find(query).First();
        }

        public void Upsert(T item)
        {
            //TODO
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Footinder.DataAccess;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Footinder.Models
{
    public class Vote : IIdentifiable
    {
        public string Date { get; set; }
        public Restaurant Restaurant { get; set; }
        public bool Decision { get; set; }
        public User User { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Footinder.DataAccess;
using MongoDB.Bson;

namespace Footinder.Models
{
    public class Vote : IMongoIdentifiable
    {
        public string Date { get; set; }
        public Restaurant Restaurant { get; set; }
        public bool Decision { get; set; }
        public User User { get; set; }
        public ObjectId Id { get; set; }
    }
}

﻿using System;
using Footinder.DataAccess;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Footinder.Models
{
    [Collection("votes")]
    public class Vote : IIdentifiable
    {
        public DateTime Date { get; set; }
        public Restaurant Restaurant { get; set; }
        public bool Decision { get; set; }
        public User User { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}

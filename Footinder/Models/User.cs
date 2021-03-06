﻿using System;
using System.Security.Cryptography;
using System.Text;
using Footinder.DataAccess;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Footinder.Models
{
    [Collection("users")]
    public class User : IIdentifiable
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }

        public string GravatarUri
        {
            get { return "http://www.gravatar.com/avatar/" + CalculateMd5Hash(Name + "@soluto.com"); }
        }

        public string CalculateMd5Hash(string input)
        {
            byte[] hash = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(input));
            var sb = new StringBuilder();
            foreach (var b in hash) sb.Append(b.ToString("X2"));

            return sb.ToString().ToLower();
        }

        public override bool Equals(object obj)
        {
        
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Id == ((User) obj).Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}

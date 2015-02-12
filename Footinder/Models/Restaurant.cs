using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Footinder.Models
{
    public class Restaurant
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int DistanceMeters { get; set; }
        public int WalkingTimeMinutes { get; set; }
        public string Address { get; set; }
        public string LogoUri { get; set; }
    }
}

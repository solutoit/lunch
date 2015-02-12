using Footinder.DataAccess;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Footinder.Models
{
    [Collection("restaurants")]
    public class Restaurant : IIdentifiable
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }
        public int DistanceMeters { get; set; }
        public int WalkingTimeMinutes { get; set; }
        public string Address { get; set; }
        public string LogoUri { get; set; }
        
        public override bool Equals(object obj)
        {
         
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Id == ((Restaurant) obj).Id;
        }
        
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}


using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace ExtendedMongoMembership.Entities
{
    [BsonIgnoreExtraElements]
    public class MembershipAccountBase
    {
        [BsonId]
        public int UserId { get; set; }
        [BsonExtraElements]
        public BsonDocument CatchAll { get; set; }
        public string UserName { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return UserId == ((MembershipAccountBase)obj).UserId;
        }

        public override int GetHashCode()
        {
            return UserId.GetHashCode();
        }
    }
}

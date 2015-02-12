using System.Security.Cryptography;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Footinder.Models
{
    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }

        public string GravatarUri
        {
            get { return CalculateMd5Hash("http://www.gravatar.com/avatar/" + Name + "@soluto.com"); }
        }

        public string CalculateMd5Hash(string input)
        {
            byte[] hash = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(input));
            var sb = new StringBuilder();
            foreach (var b in hash) sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

    }
}

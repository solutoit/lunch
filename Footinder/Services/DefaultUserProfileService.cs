
using ExtendedMongoMembership.Services;
using Footinder.Models;

namespace Footinder.Services
{
    public class DefaultUserProfileService : UserProfileServiceBase<User>
    {
        public DefaultUserProfileService(string connectionString)
            : base(connectionString)
        {

        }
    }
}
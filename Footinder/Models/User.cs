using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Footinder.DataAccess;

namespace Footinder.Models
{
    [Collection("users")]
    public class User : IIdentifiable
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

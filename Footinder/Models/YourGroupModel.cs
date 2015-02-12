using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Footinder.Models
{
    public class YourGroupModel
    {
        public Restaurant Restaurant { get; set; }
        public List<User> GroupUsers { get; set; }
        public User CurrentUser { get; set; }
        public DateTime LaunchTime { get; set; }
    }
}
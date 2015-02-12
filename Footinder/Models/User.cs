﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedMongoMembership.Entities;

namespace Footinder.Models
{
    public class User : MembershipAccountBase
    {
        // public string Id { get; set; } //UserId is in the base class
        public string Name { get; set; }
    }
}

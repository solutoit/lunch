using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footinder.Models
{
    public class Vote
    {
        public string Date { get; set; }
        public Restaurant Restaurant { get; set; }

        public bool Decision { get; set; }
        public User User { get; set; }
    }
}

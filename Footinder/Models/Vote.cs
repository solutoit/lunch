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
        public string RestauarantId { get; set; }

        public bool Decision { get; set; }
        public string UserId { get; set; }
    }
}

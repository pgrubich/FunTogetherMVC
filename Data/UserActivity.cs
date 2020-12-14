using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunTogether.Data
{
    public class UserActivity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }       
        public bool IsHost { get; set; }
    }
}

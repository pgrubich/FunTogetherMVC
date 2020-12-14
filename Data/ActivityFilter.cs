using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunTogether.Data
{
    public class ActivityFilter
    {
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
        public int FilterId { get; set; }
        public Filter Filter { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FunTogether.Data
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public double LocationLongitude { get; set; }
        public double LocationLatitude { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public ICollection<UserActivity> UserActivities { get; set; }
        public ICollection<ActivityFilter> ActivityFilters { get; set; }
    }
}

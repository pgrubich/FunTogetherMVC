using FunTogether.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunTogether.Models
{
    public class ActivitySearchFilterModel
    {
        public string City { get; set; }
        public string[] SelectedCategories { get; set; }
        public ActivityType[] Categories { get; set; }
        public int PageNumber { get; set; }
    }
}

using FunTogether.Data;
using FunTogether.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunTogether.Filters
{
    public class FilterHelper
    {
        public static IQueryable<Activity> GetActivities(IQueryable<Activity> activities, ActivitySearchFilterModel filter)
        {
            if (filter == null) return activities;
            
            var result = activities;
            if (!string.IsNullOrEmpty(filter.City))
                result = result.Where(a => a.City == filter.City);

            if (filter.SelectedCategories != null && filter.SelectedCategories.Length > 0)
            {               
                List<ActivityType> activityFilters = new List<ActivityType>();
                //Parse string categories to enum
                foreach (string c in filter.SelectedCategories)
                {
                    activityFilters.Add((ActivityType)Enum.Parse(typeof(ActivityType), c));
                }
                result = result.Where(a => activityFilters.Contains(a.Type));
            }
            return result;
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunTogether.Data;

namespace FunTogether.Models
{
    public class ActivityViewModel
    {
        [Display(Name = "Activity title")]
        [Required, MaxLength(60)]
        public string Title { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Location { get; set; }
        public double LocationLongitude { get; set; }
        public double LocationLatitude { get; set; }
        public string City { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }

        [Display(Name = "Activity category")]
        public int ActivityTypeId { get; set; }
        public ActivityType Type { get; set; }

        [Display(Name = "Preferred age of participants")]
        public List<Filter> AgeGroups { get; set; }
        [Display(Name = "Preferred gender of participants")]
        public List<Filter> Genders { get; set; }
    }
}

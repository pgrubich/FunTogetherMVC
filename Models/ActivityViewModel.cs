using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunTogether.Models
{
    public class ActivityViewModel
    {
        [Display(Name = "Activity title")]
        [Required, MaxLength(60)]
        public string Title { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public double LocationLongitude { get; set; }
        public double LocationLatitude { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }

    }
}

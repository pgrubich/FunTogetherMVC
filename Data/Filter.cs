using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FunTogether.Data
{
    public class Filter
    {
        [Key]
        public int Id { get; set; }
        public FilterCategory Category { get; set; }
        public string Value { get; set; }
        public ICollection<ActivityFilter> ActivityFilters { get; set; }
        [NotMapped]
        public bool Selected { get; set; }

        public enum FilterCategory
        {
            AgeGroup,
            Gender
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FunTogether.Data
{
    public class Filter
    {
        [Key]
        public int Id { get; set; }
        public string Category { get; set; }
        public string Value { get; set; }
        public ICollection<ActivityFilter> ActivityFilters { get; set; }
    }
}

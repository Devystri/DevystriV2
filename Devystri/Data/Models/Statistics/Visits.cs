using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models.Statistics
{
    public class Visits
    {
        [Key]
        public int Id { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}

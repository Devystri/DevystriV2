using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models.Statistics
{
    public class Visits
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }
        public DateTime Date { get; set; }
    }
}

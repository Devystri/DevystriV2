using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models.Dashboard
{
    public class StatisticsModel
    {
        List<int> TotalVisits { get; set; }
        List<int> MeanTime { get; set; }
        List<int> NewMessages { get; set; }
        List<VisitsPerPage> VisitsPages { get; set; }
    }   
}

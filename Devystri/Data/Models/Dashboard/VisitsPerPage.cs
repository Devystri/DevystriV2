using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models.Dashboard
{
    public class VisitsPerPage
    {
        public int PageId { get; set; }
        public string PageName { get; set; }
        public List<int> Count{ get; set; }
    }
}

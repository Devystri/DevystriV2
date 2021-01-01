using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Section
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Title{ get; set; }
        public string Description{ get; set; }
    }
}

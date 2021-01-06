using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Section
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Title{ get; set; }
        public string Description{ get; set; }
    }
}

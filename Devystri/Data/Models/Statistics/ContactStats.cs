using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models.Statistics
{
    public class ContactStats
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public int Count { get; set; }

        [DataType(DataType.EmailAddress)]
        public DateTime Date{ get; set; }
    }
}

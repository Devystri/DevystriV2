using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class UserGroup
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }
    }
}

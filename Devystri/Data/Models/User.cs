using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [MinLength(2)]
        [Required]
        public string Name { get; set; }
        [MinLength(2)]
        [Required]
        public string FirstName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime CreationDateTime { get; set; }
        [Required]
        public DateTime? LastUpdateDateTime { get; set; }
    }
}

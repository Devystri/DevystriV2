using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Newsletter
    {
        [Key]
        public int Id { get; set; }
        
        [DataType(DataType.EmailAddress, ErrorMessage = "Veuillez saisir une email valide.")]
        [Required]
        public string Email { get; set; }
        
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime Date{ get; set; }
    }
}

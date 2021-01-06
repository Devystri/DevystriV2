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
        
        [MinLength(3, ErrorMessage = "Votre nom doit contenir au moins 3 caractères.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Veuillez spécifier un nom.")]
        public string Name { get; set; }
        
        [MinLength(3, ErrorMessage = "Votre prénom doit contenir au moins 3 caractères.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Veuillez spécifier un prénom.")]
        public string FirstName { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Veuillez préciser une adresse email.")]
        [EmailAddress(ErrorMessage = "Veuillez spécifier une adresse email valide.")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Veuillez spécifier un mot de passe.")]
        public string Password { get; set; }
        [Required]
        public DateTime CreationDateTime { get; set; }
        [Required]
        public DateTime? LastUpdateDateTime { get; set; }
    }
}

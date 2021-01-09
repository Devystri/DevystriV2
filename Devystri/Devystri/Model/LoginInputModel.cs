using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Devystri.Model
{
    public class LoginInputModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Adresse email invalide.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password, ErrorMessage = "Le mot de ne respecte pas les contraintes.")]
    
        [MinLength(8, ErrorMessage = "La longueur du mot de passe doit être comprise entre 8 et 16 caractères.")]
        [MaxLength(16, ErrorMessage = "La longueur du mot de passe doit être comprise entre 8 et 16 caractères.")]
        public string Password { get; set; }
    }
}

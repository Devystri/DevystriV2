using System;
using System.ComponentModel.DataAnnotations;

namespace Devystri.Model.Admin
{
    public class NewAccountInput
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Veuillez spécifier un nom d'utilisateur.")]
        [StringLength(24, ErrorMessage = "Veuillez spécifier un nom d'utilisateur contenant entre 3 et 24 caractères", MinimumLength = 3)]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Veuillez spécifier une adresse email.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Veuillez spécifier une adresse email valide.")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Veuillez spécifier un mot de passe.")]
        [StringLength(24, ErrorMessage = "Veuillez saisir un mot de passe contenant entre 8 et 24 caractères", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Veuillez comfirmer votre mot de passe.")]
        [StringLength(24, ErrorMessage = "Veuillez saisir un mot de passe contenant entre 8 et 24 caractères", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string ComfirmationPassword { get; set; }


    }
}

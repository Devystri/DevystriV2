using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Devystri.Model
{
    public class ChangePasswordInputModel
    {
        [EmailAddress(ErrorMessage = "Veuillez saisir une email valide")]
        public string Email { get; set; }
        public string Password { get; set; }

        [DataType(DataType.Password, ErrorMessage = "Le nouveau mot de passe ne respecte pas les contraintes.")]
        public string NewPassword { get; set; }
        public string NewPasswordConfirm { get; set; }
    }
}

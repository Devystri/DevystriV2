using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Devystri.Model
{
    public class ContactInputForm
    {

        [StringLength(28, ErrorMessage = "Votre nom doit contenir entre 3 et 28 caractères.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [StringLength(28, ErrorMessage = "Votre prénom doit contenir entre 3 et 28 caractères.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        
        [EmailAddress(ErrorMessage = "Veuillez entrer une adresse email valide.")]
        public string Email { get; set; }

        [StringLength(28, ErrorMessage = "Le sujet doit contenir entre 6 et 28 caractères.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        public string Subject { get; set; }
        
        [StringLength(1500, ErrorMessage = "Le message doit contenir entre 32 et 1500 caractères.", MinimumLength = 32)]
        [DataType(DataType.Text)]
        public string Message { get; set; }
    }
}

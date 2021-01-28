using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Devystri.Model
{
    public class NewsletterInputModel
    {
        [EmailAddress(ErrorMessage = "Veuillez saisir une adresse email valide.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Veuillez spécifier votre adresse email.")]
        public string Email { get; set; }
    }
}

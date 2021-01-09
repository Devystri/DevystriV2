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
        public string Email { get; set; }
    }
}

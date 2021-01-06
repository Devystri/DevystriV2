using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class WebSites
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [MinLength(3, ErrorMessage = "Veuillez spécifier un nom d'au moins 3 caractères.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Veuillez spécifier un nom de site web.")]
        public string Name { get; set; }

        [MinLength(12, ErrorMessage = "La description doit contenir au moins 12 caractères.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Veuillez spécifier une description.")]
        public string Description { get; set; }

        [Url(ErrorMessage = "Veuillez spécifier une URL valide.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Veuillez spécifier une URL.")]
        public string Link { get; set; }

        [DataType(DataType.ImageUrl, ErrorMessage = "Veuillez spécifier un logo valide.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Veuillez spécifier une nom de logo.")]
        public string AppLogoName { get; set; }

        [DataType(DataType.ImageUrl, ErrorMessage = "Veuillez une ressource.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Veuillez une ressource.")]
        public string PresentationRessource{ get; set; }
        [Required]
        public int Stat { get; set; }
    }
}

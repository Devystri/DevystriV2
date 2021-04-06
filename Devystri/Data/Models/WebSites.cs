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

        public string Language { get; set; }

        public int MinAge { get; set; }


        [DataType(DataType.ImageUrl, ErrorMessage = "Vous n'avez pas saisi un nom d'image correct.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vous n'avez pas saisi un nom de ressource correct")]
        public string PresentationRessourceName { get; set; }

        [DataType(DataType.ImageUrl, ErrorMessage = "Vous n'avez pas saisi un nom d'image correct.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vous n'avez pas saisi un nom de ressource correct")]
        public string Presentation2RessourceName { get; set; }

        [DataType(DataType.ImageUrl, ErrorMessage = "Vous n'avez pas saisi un nom d'image correct.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vous n'avez pas saisi un nom de ressource correct")]
        public string Presentation3RessourceName { get; set; }

        [Required]
        public Stats Stat { get; set; }
    }
}

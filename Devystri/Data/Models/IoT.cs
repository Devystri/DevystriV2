using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class IoT
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [MinLength(3, ErrorMessageResourceName = "Le nom du fichier doit au moins contenir 3 caractères.")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Veuillez saisir le nom du projet.")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [MinLength(12, ErrorMessageResourceName = "La description doit contenir au minimum 12 caractères.")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Veuillez saisir une description.")]
        public string Description { get; set; }
        public float Price { get; set; }

        [DataType(DataType.ImageUrl, ErrorMessage = "Vous n'avez pas saisi un nom d'image correct.")]
        [Required]
        public string LogoName { get; set; }

        [DataType(DataType.ImageUrl, ErrorMessage = "Vous n'avez pas saisi un nom d'image correct.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vous n'avez pas saisi un nom de ressource correct")]
        public string PresentationRessourceName { get; set; }

        [DataType(DataType.ImageUrl, ErrorMessage = "Vous n'avez pas saisi un nom d'image correct.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vous n'avez pas saisi un nom de ressource correct")]
        public string Presentation2RessourceName { get; set; }

        [DataType(DataType.ImageUrl, ErrorMessage = "Vous n'avez pas saisi un nom d'image correct.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vous n'avez pas saisi un nom de ressource correct")]
        public string Presentation3RessourceName { get; set; }
        public Stats Stat { get; set; }
    } 
}

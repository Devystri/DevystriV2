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

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Veuillez saisir le nom d'une ressource de présentation.")]
        [DataType(DataType.ImageUrl, ErrorMessageResourceName = "Veuillez spécifier une ressource valide.")]
        public string PresentationRessource { get; set; }
        public int Stat { get; set; }
    } 
}

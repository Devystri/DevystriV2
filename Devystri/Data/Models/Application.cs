﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Application
    {
        [Required]
        public int Id { get; set; }

        [MinLength(3, ErrorMessage = "Veuillez spécifier un nom d'au moins 3 caractères.")]
        [DataType(DataType.Text, ErrorMessage = "La saisie est invalide.")]
        [Required(AllowEmptyStrings = false, ErrorMessage ="Veuillez spécifier un nom.")]
        public string Name { get; set; }

        [MinLength(12, ErrorMessage = "La description doit au moins contenir 12 caractères.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Veuillez spécifier une desciption.")]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        public int IsOnAppStore { get; set; }
        public int IsOnPlayStore { get; set; }
       
        [DataType(DataType.ImageUrl, ErrorMessage = "Vous n'avez pas saisi un nom d'image correct.")]
        [Required]
        public string AppLogoName { get; set; }
        
        [MinLength(12)]
        [DataType(DataType.ImageUrl, ErrorMessage = "Vous n'avez pas saisi un nom d'image correct.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vous n'avez pas saisi un nom de ressource correct")]
        public string PresentationRessource { get; set; }
        
        public int Stat { get; set; }
    }
}

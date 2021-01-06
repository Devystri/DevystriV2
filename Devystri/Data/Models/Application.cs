using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Application
    {
        [Required]
        public int Id { get; set; }

        [MinLength(4)]
        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }

        [MinLength(12)]
        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        public int IsOnAppStore { get; set; }
        public int IsOnPlayStore { get; set; }
       
        [DataType(DataType.ImageUrl)]
        [Required]
        public string AppLogoName { get; set; }
        
        [MinLength(12)]
        [DataType(DataType.ImageUrl)]
        [Required]
        public string PresentationRessource { get; set; }
        
        public int Stat { get; set; }
    }
}

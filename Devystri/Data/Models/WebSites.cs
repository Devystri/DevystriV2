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
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Url]
        public string Link { get; set; }
        [Required]
        public string AppLogoName { get; set; }
        [Required]
        public string PresentationRessource{ get; set; }
        [Required]
        public int Stat { get; set; }
    }
}

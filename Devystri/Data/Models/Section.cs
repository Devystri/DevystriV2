using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Section
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Veuillez spécifier le titre de la section.")]
        public string Title{ get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Veuillez spécifier une description.")]
        public string Description{ get; set; }
        public string ImageSrc{ get; set; }
    }
}

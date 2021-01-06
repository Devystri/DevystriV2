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
        public string Name { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }
        public float Price { get; set; }
        [DataType(DataType.ImageUrl)]
        public string PresentationRessource { get; set; }
        public int Stat { get; set; }
    } 
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class WebSites
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string AppLogoName { get; set; }
        public string PresentationRessource{ get; set; }
        public int Stat { get; set; }
    }
}

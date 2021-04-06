using System;
using Data.Models;
using Microsoft.AspNetCore.Http;

namespace Devystri.Model.Admin
{
    public class IotImportModel
    {
        public IotImportModel()
        {
            LogoName = (Logo is null) ? "addPicture.svg" : PresentationRessource.FileName;
            PresentationRessourceName = (PresentationRessource is null) ? "addPicture.svg" : PresentationRessource.FileName;
            Presentation2RessourceName = (Presentation2Ressource is null) ? "addPicture.svg" : Presentation2Ressource.FileName;
            Presentation3RessourceName = (Presentation3Ressource is null) ? "addPicture.svg" : Presentation3Ressource.FileName;
        }

        public IotImportModel(IoT iot)
        {
            Id = iot.Id;
            Name = iot.Name;
            Description = iot.Description;
            LogoName = iot.LogoName;
            Price = iot.Price;
            PresentationRessourceName = iot.PresentationRessourceName;
            Presentation2RessourceName = iot.Presentation2RessourceName;
            Presentation3RessourceName = iot.Presentation3RessourceName;
            State = (Stats)iot.Stat;
        }

        public IoT ToIot()
        {
            return new IoT()
            {
                Id = Id,
                Price = Price,
                LogoName = LogoName,
                Description = Description,
                Name = Name,
                Presentation2RessourceName = Presentation2RessourceName,
                Presentation3RessourceName = Presentation3RessourceName,
                PresentationRessourceName = PresentationRessourceName,
                Stat = State
            };
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public float Price { get; set; }

        public string LogoName { get; set; }
        public IFormFile Logo { get; set; }


        public string PresentationRessourceName { get; set; }
        public IFormFile PresentationRessource { get; set; }

        public string Presentation2RessourceName { get; set; }
        public IFormFile Presentation2Ressource { get; set; }

        public string Presentation3RessourceName { get; set; }
        public IFormFile Presentation3Ressource { get; set; }

        public Stats State { get; set; }
    
    }
}

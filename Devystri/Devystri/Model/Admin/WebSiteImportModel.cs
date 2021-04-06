using System;
using Data.Models;
using Microsoft.AspNetCore.Http;

namespace Devystri.Model.Admin
{
    public class WebSiteImportModel
    {

        public WebSiteImportModel()
        {
            AppLogoName = (AppLogo is null) ? "addPicture.svg" : AppLogo.FileName;
            PresentationRessourceName = (PresentationRessource is null) ? "addPicture.svg" : PresentationRessource.FileName;
            Presentation2RessourceName = (Presentation2Ressource is null) ? "addPicture.svg" : Presentation2Ressource.FileName;
            Presentation3RessourceName = (Presentation3Ressource is null) ? "addPicture.svg" : Presentation3Ressource.FileName;
        }

        public WebSiteImportModel(WebSite web)
        {
            Id = web.Id;
            Name = web.Name;
            Description = web.Description;
            MinAge = web.MinAge;
            Language = web.Language;
            Link = web.Link;
            AppLogoName = web.AppLogoName;
            PresentationRessourceName = web.PresentationRessourceName;
            Presentation2RessourceName = web.Presentation2RessourceName;
            Presentation3RessourceName = web.Presentation3RessourceName;
            State = (Stats)web.Stat;
        }

        public WebSite ToWebSite()
        {
            return new WebSite()
            {
                Id = Id,
                AppLogoName = AppLogo.Name,
                Description = Description,
                Stat = State,
                Link = Link,
                Language = Language,
                MinAge = MinAge,
                Name = Name,
                
                PresentationRessourceName = PresentationRessource.FileName,
                Presentation2RessourceName = Presentation2Ressource.FileName,
                Presentation3RessourceName = Presentation3Ressource.FileName,

                
            };
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public int MinAge { get; set; }

        public string Language { get; set; }

        public IFormFile AppLogo { get; set; }
        public string AppLogoName { get; set; }

        public IFormFile PresentationRessource { get; set; }
        public string PresentationRessourceName { get; set; }

        public IFormFile Presentation2Ressource { get; set; }
        public string Presentation2RessourceName { get; set; }

        public IFormFile Presentation3Ressource { get; set; }
        public string Presentation3RessourceName { get; set; }

        public Stats State { get; set; }
        
    }
}

using System.ComponentModel.DataAnnotations;
using Data.Models;
using Devystri.Modules;
using Microsoft.AspNetCore.Http;

namespace Devystri.Model.Admin
{
    public class ApplicationImportModel
    {
        public ApplicationImportModel()
        {

        }

        public ApplicationImportModel(Application application)
        {
            Id = application.Id;
            Name = application.Name;
            Description = application.Description;
            MinAge = application.MinAge;
            Languages = application.Languages;
            IsOnAppStore = application.IsOnAppStore;
            IsOnPlayStore = application.IsOnPlayStore;
            AppStoreLink = application.AppStoreLink;
            PlayStoreLink = application.PlayStoreLink;
            AppLogoName = application.AppLogoName;
            PresentationRessourceName = application.PresentationRessourceName;
        }
        public Application ToApplication(Application application)
        {
            return new Application()
            {
                Id = Id,
                AppLogoName = (application.AppLogoName == AppLogoName)? (AppLogoName):(application.AppLogoName),
                AppStoreLink = AppStoreLink,
                Description = Description,
                IsOnAppStore = IsOnAppStore,
                IsOnPlayStore = IsOnPlayStore,
                Languages = Languages,
                MinAge = MinAge,
                Name = Name,
                PlayStoreLink = PlayStoreLink,
                PresentationRessourceName = (application.PresentationRessourceName == PresentationRessourceName) ? (PresentationRessourceName) : (application.PresentationRessourceName)
            };
        }
        public Application ToApplication()
        {
            return new Application()
            {
                Id = Id,
                AppLogoName = AppLogo.Name,
                AppStoreLink = AppStoreLink,
                Description = Description,
                IsOnAppStore = IsOnAppStore,
                IsOnPlayStore = IsOnPlayStore,
                Languages = Languages,
                MinAge = MinAge,
                Name = Name,
                PlayStoreLink = PlayStoreLink,
                PresentationRessourceName = PresentationRessource.FileName
            };
        }

        public string ImageName(IFormFile file, string actualName, ImageImport imageImport)
        {
            if (file is not null)
            {
                if (actualName != file.FileName)
                {
                    actualName = file.FileName;
                    imageImport.Delete(actualName);
                }

            }

            return actualName;
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int MinAge { get; set; }
        [Required]
        public string Languages { get; set; }
        [Required]
        public bool IsOnAppStore { get; set; }
        [Required]
        public bool IsOnPlayStore { get; set; }

        public string AppStoreLink { get; set; }
        public string PlayStoreLink { get; set; }

        public IFormFile AppLogo { get; set; }
        public string AppLogoName { get; set; }

        public IFormFile PresentationRessource { get; set; }
        public string PresentationRessourceName { get; set; }

        public IFormFile Presentation2Ressource { get; set; }
        public string Presentation2RessourceName { get; set; }

        public IFormFile Presentation3Ressource { get; set; }
        public string Presentation3RessourceName { get; set; }
    }
}

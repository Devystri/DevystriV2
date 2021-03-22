using Data.Models;
using Devystri.Modules;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            PresentationRessourceName = application.PresentationRessource;
        }
        public Application ToApplication()
        {
            return new Application()
            {
                Id = Id,
                AppLogoName = AppLogo.FileName,
                AppStoreLink = AppStoreLink,
                Description = Description,
                IsOnAppStore = IsOnAppStore,
                IsOnPlayStore = IsOnPlayStore,
                Languages = Languages,
                MinAge = MinAge,
                Name = Name,
                PlayStoreLink = PlayStoreLink,
                PresentationRessource = ""
            };
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinAge { get; set; }
        public string Languages { get; set; }
        public bool IsOnAppStore { get; set; }
        public bool IsOnPlayStore { get; set; }

        public string AppStoreLink { get; set; }
        public string PlayStoreLink { get; set; }
        public IFormFile AppLogo { get; set; }
        public string AppLogoName { get; set; }

        public IFormFile PresentationRessource { get; set; }
        public string PresentationRessourceName { get; set; }
    }
}

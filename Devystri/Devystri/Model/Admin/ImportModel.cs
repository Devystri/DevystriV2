using System.Collections.Generic;
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
            Presentation2RessourceName = application.Presentation2RessourceName;
            Presentation3RessourceName = application.Presentation3RessourceName;
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
                PresentationRessourceName = PresentationRessource.FileName,
                Presentation2RessourceName = Presentation2Ressource.FileName,
                Presentation3RessourceName = Presentation3Ressource.FileName
            };
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


    public class SectionImport
    {
        public SectionImport()
        {

        }

        public SectionImport(Section section)
        {
            Id = section.Id;
            ProjectId = section.ProjectId;
            Title = section.Title;
            Description = section.Description;
            ImageSrc = section.ImageSrc;
        }

        public Section ToSection()
        {
            return new Section()
            {
                Id = Id,
                ProjectId = ProjectId,
                ImageSrc = ImageSrc,
                Description = Description,
                Title = Title

            };

        }

        public int Id { get; set; }

        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageSrc { get; set; }
        public IFormFile Image { get; set; }
    }

    public static class ImportTools
    {
        public static string ImageName(IFormFile file, string actualName, ImageImport imageImport)
        {
            if(actualName is not null)
                actualName = actualName.Replace(" ", string.Empty);
            if (file is not null)
            {
                if (actualName != file.FileName.Replace(" ", string.Empty))
                {
                    actualName = file.FileName.Replace(" ", string.Empty);
                    imageImport.Delete(actualName);
                }

            }

            return actualName;
        }

       public static List<SectionImport> ToSectionImportList(List<Section> list)
        {
            List<SectionImport> sectionImports = new List<SectionImport>();
            foreach (var item in list)
            {
                sectionImports.Add(new SectionImport(item));
            }

            return sectionImports;
        }
    }
}

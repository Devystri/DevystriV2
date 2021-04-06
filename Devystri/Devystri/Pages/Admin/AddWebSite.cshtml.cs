using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Devystri.Model.Admin;
using Devystri.Modules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Devystri.Pages.Admin
{
#if RELEASE
    [Authorize]
#endif
    public class AddWebSiteModel : PageModel
    {
        [BindProperty]
        public WebSiteImportModel WebSite { get; set; }
        [BindProperty]

        public List<SectionImport> Sections { get; set; }

        public List<WebSite> ListWebSites { get; set; }

        public int AppId { get; set; }

        public bool Success { get; set; }
        public string Message { get; set; }

        private ImageImport imageImport = new ImageImport("wwwroot/upload/websites/");
        private MyDbContext dbContext;

        public AddWebSiteModel(MyDbContext context)
        {
            dbContext = context;
        }

        public void OnGet(int id = 0)
        {
            AppId = id;
            LoadPage();

        }

        public void OnPost()
        {
            AppId = WebSite.Id;
            SaveApp();
            LoadPage();
        }

        public void OnGetAddSection(int id)
        {
            var newSection = new Section();
            newSection.ProjectId = id;
            dbContext.Sections.Add(newSection);
            dbContext.SaveChanges();
            AppId = id;
            LoadPage();

        }

        public void SaveApp()
        {
            Success = false;
            ListWebSites = dbContext.WebSites.ToList();

            if (ListWebSites.Exists(item => item.Id == WebSite.Id))
            {
                var toEdit = ListWebSites.FirstOrDefault(item => item.Id == WebSite.Id);
                if (toEdit != null)
                {
                    toEdit.Name = WebSite.Name;
                    toEdit.Language = WebSite.Language;
                    toEdit.Description = WebSite.Description;
                    toEdit.Link = WebSite.Link;
                    toEdit.MinAge = WebSite.MinAge;
                    toEdit.PresentationRessourceName = ImportTools.ImageName(WebSite.PresentationRessource, toEdit.PresentationRessourceName, imageImport);
                    toEdit.AppLogoName = ImportTools.ImageName(WebSite.AppLogo, toEdit.AppLogoName, imageImport);
                    toEdit.Presentation2RessourceName = ImportTools.ImageName(WebSite.Presentation2Ressource, toEdit.Presentation2RessourceName, imageImport);
                    toEdit.Presentation3RessourceName = ImportTools.ImageName(WebSite.Presentation3Ressource, toEdit.Presentation3RessourceName, imageImport);
                    toEdit.Stat = WebSite.State;

                    dbContext.WebSites.Update(toEdit);
                    var sections = dbContext.Sections.Where(item => item.ProjectId == AppId).ToList();
                    if (Sections is not null)
                    {
                        foreach (var item in Sections)
                        {

                            var el = sections.FirstOrDefault(el => item.Id == el.Id);
                            el.Description = item.Description;
                            el.ImageSrc = ImportTools.ImageName(item.Image, el.ImageSrc, imageImport);
                            el.Title = item.Title;
                            sections.Remove(sections.FirstOrDefault(sec => sec.Id == item.Id));
                            dbContext.Sections.Update(el);
                        }

                        foreach (var section in sections)
                        {
                            dbContext.Sections.Remove(dbContext.Sections.FirstOrDefault(item => item.Id == section.Id));
                        }
                    }
                    Success = true;
                    Message = "Les modifications ont été apportés avec succès";
                }
                else
                {
                    Success = false;
                    Message = "Le site internet n'a pas pu être modifié pour une raison inconnue.";

                }


            }
            else
            {
                var empty = new WebSiteImportModel();
                if (WebSite == empty)
                {
                    Success = false;
                    Message = "Impossible d'ajouter un site web sans informations.";
                    return;
                }
                var app = WebSite.ToWebSite();
                dbContext.WebSites.Add(app);
                Message = "Le site internet a été ajouté avec succès.";
                Success = true;

            }
            if (!imageImport.Import(HttpContext.Request.Form.Files))
            {
                Success = false;
                Message = "Impossible d'ajouter ces images.";
                return;
            }
            try
            {
                dbContext.SaveChanges();
                Success = true;
            }
            catch (Exception)
            {
                Success = false;
                Message = "Le site internet n'a pas pu être modifié pour une raison inconnue.";
            }
        }

        public IActionResult OnPostDelete()
        {
            Success = false;
            var form = HttpContext.Request.Form;
            foreach (var el in form)
            {
                if (el.Value[0] == "on")
                {
                    int id = int.Parse(el.Key);
                    dbContext.WebSites.Remove((WebSite)dbContext.WebSites.First(item => item.Id == id));

                }
            }
            try
            {
                dbContext.SaveChanges();
                Success = true;
                Message = "Le site internet a été supprimé avec succès.";
            }
            catch (Exception)
            {
                Message = "Le site internet n'a pas pu être supprimé.";
            }
            return RedirectToPage("/Admin/AddWebSite");
        }

        public void LoadPage()
        {
            ListWebSites = dbContext.WebSites.ToList();

            if (AppId == 0)
            {
                WebSite = new WebSiteImportModel();
                Sections = new List<SectionImport>();
            }
            else
            {
                if (ListWebSites.Exists(item => item.Id == AppId))
                {

                    WebSite = new WebSiteImportModel(ListWebSites.First(item => item.Id == AppId));
                    Sections = ImportTools.ToSectionImportList(dbContext.Sections.Where(item => item.ProjectId == AppId).ToList());

                }
                else
                {
                    Sections = new List<SectionImport>();
                    WebSite = new WebSiteImportModel();
                    AppId = 0;
                }
            }

        }
    }
}

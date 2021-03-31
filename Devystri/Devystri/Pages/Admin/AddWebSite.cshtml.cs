using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Devystri.Model.Admin;
using Devystri.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Devystri.Pages.Admin
{
    public class AddWebSiteModel : PageModel
    {
        [BindProperty]
        public WebSiteImportModel WebSite { get; set; }
        [BindProperty]
        public List<SectionImport> Sections { get; set; }
        [BindProperty]
        public List<WebSites> ListWebSites { get; set; }
        [BindProperty]
        public int AppId { get; set; }

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
                    toEdit.PresentationRessourceName = ImportTools.ImageName(WebSite.PresentationRessource, toEdit.PresentationRessourceName, imageImport);
                    toEdit.AppLogoName = ImportTools.ImageName(WebSite.AppLogo, toEdit.AppLogoName, imageImport);
                    toEdit.Presentation2RessourceName = ImportTools.ImageName(WebSite.Presentation2Ressource, toEdit.Presentation2RessourceName, imageImport);
                    toEdit.Presentation3RessourceName = ImportTools.ImageName(WebSite.Presentation3Ressource, toEdit.Presentation3RessourceName, imageImport);

                    dbContext.WebSites.Update(toEdit);
                    var sections = dbContext.Sections.Where(item => item.ProjectId == AppId).ToList();
                    foreach (var item in Sections)
                    {

                        var el = sections.FirstOrDefault(el => item.Id == el.Id);
                        el.Description = item.Description;
                        el.ImageSrc = ImportTools.ImageName(item.Image, item.ImageSrc, imageImport);
                        el.Title = item.Title;
                        dbContext.Sections.Update(el);
                    }

                }


            }
            else
            {
                var app = WebSite.ToApplication();
                dbContext.WebSites.Add(app);

            }
            if (!imageImport.Import(HttpContext.Request.Form.Files))
            {
                return;
            }
            dbContext.SaveChanges();
        }

        public IActionResult OnPostDelete()
        {
            var form = HttpContext.Request.Form;
            foreach (var el in form)
            {
                if (el.Value[0] == "on")
                {
                    int id = int.Parse(el.Key);
                    dbContext.WebSites.Remove((WebSites)dbContext.WebSites.First(item => item.Id == id));

                }
            }
            dbContext.SaveChanges();
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

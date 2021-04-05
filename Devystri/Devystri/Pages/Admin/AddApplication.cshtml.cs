using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Devystri.Model.Admin;
using Devystri.Modules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using SixLabors.ImageSharp;

namespace Devystri.Pages.Admin
{
#if RELEASE
    [Authorize]
#endif
    public class AddApplicationModel : PageModel
    {
        [BindProperty]
        public ApplicationImportModel Application { get; set; }
        [BindProperty]
        public List<SectionImport> Sections { get; set; }
        [BindProperty]
        public List<Application> ListApp { get; set; }
        [BindProperty]
        public int AppId{ get; set; }

        private ImageImport imageImport = new ImageImport("wwwroot/upload/applications/");
        private MyDbContext dbContext;

        public AddApplicationModel(MyDbContext context)
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
            AppId = Application.Id;
            SaveApp();
            LoadPage();
        }

        public void SaveApp()
        {
            ListApp = dbContext.Applications.ToList();

            if (ListApp.Exists(item => item.Id == Application.Id))
            {
                var toEdit = ListApp.FirstOrDefault(item => item.Id == Application.Id);
                if (toEdit != null)
                {
                    toEdit.Name = Application.Name;
                    toEdit.Languages = Application.Languages;
                    toEdit.Description = Application.Description;
                    toEdit.AppStoreLink = Application.AppStoreLink;
                    toEdit.PresentationRessourceName = ImportTools.ImageName(Application.PresentationRessource, toEdit.PresentationRessourceName, imageImport);
                    toEdit.AppLogoName = ImportTools.ImageName(Application.AppLogo, toEdit.AppLogoName, imageImport);
                    toEdit.Presentation2RessourceName = ImportTools.ImageName(Application.Presentation2Ressource, toEdit.Presentation2RessourceName, imageImport);
                    toEdit.Presentation3RessourceName = ImportTools.ImageName(Application.Presentation3Ressource, toEdit.Presentation3RessourceName, imageImport);

                    dbContext.Applications.Update(toEdit);
                    var sections = dbContext.Sections.Where(item => item.ProjectId == AppId).ToList();
                    foreach (var item in Sections)
                    {
                       
                        var el = sections.FirstOrDefault(el => item.Id == el.Id);
                        el.Description = item.Description;
                        el.ImageSrc = ImportTools.ImageName(item.Image, el.ImageSrc, imageImport);
                        el.Title = item.Title;
                        dbContext.Sections.Update(el);
                    }

                }


            }
            else
            {
                var app = Application.ToApplication();
                dbContext.Applications.Add(app);

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
                    dbContext.Applications.Remove((Application)dbContext.Applications.First(item => item.Id == id));

                }
            }
            dbContext.SaveChanges();
            return RedirectToPage("/Admin/AddApplication");
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

        public void LoadPage()
        {
            ListApp = dbContext.Applications.ToList();

            if (AppId == 0)
            {
                Application = new ApplicationImportModel();
                Sections = new List<SectionImport>();
            }
            else
            {
                if (ListApp.Exists(item => item.Id == AppId))
                {

                    Application = new ApplicationImportModel(ListApp.First(item => item.Id == AppId));
                    Sections = ImportTools.ToSectionImportList(dbContext.Sections.Where(item => item.ProjectId == AppId).ToList());

                }
                else
                {
                    Sections = new List<SectionImport>();
                    Application = new ApplicationImportModel();
                    AppId = 0;
                }
            }

        }
    }
}

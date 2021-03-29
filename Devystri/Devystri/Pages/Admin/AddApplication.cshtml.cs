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
#if REALESE
    [Authorize]
#endif
    public class AddApplicationModel : PageModel
    {
        [BindProperty]
        public ApplicationImportModel Application { get; set; }
        [BindProperty]
        public List<Section> Sections { get; set; }
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
            ListApp = dbContext.Applications.ToList();

            imageImport.Import(HttpContext.Request.Form.Files);
            if (ListApp.Exists(item => item.Id == Application.Id))
            {
                var toEdit = ListApp.FirstOrDefault(item => item.Id == Application.Id);
                if(toEdit != null)
                {
                    toEdit.Name = Application.Name;
                    toEdit.Languages = Application.Languages;
                    toEdit.Description = Application.Description;
                    toEdit.AppStoreLink = Application.AppStoreLink;
                    toEdit.PresentationRessourceName = "";
                    toEdit.AppLogoName = Application.ImageName(Application.AppLogo, toEdit.AppLogoName, imageImport);
                    dbContext.Applications.Update(toEdit);
                }
                
            }
            else
            {
                var app = Application.ToApplication();
                dbContext.Applications.Add(app);

            }
            dbContext.SaveChanges();
            LoadPage();
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

        public void LoadPage()
        {
            ListApp = dbContext.Applications.ToList();

            if (AppId == 0)
            {
                Application = new ApplicationImportModel();
                Sections = new List<Section>();
            }
            else
            {
                if (ListApp.Exists(item => item.Id == AppId))
                {

                    Application = new ApplicationImportModel(ListApp.First(item => item.Id == AppId));
                    Sections = dbContext.Sections.Where(item => item.ProjectId == AppId).ToList();

                }
                else
                {
                    Sections = new List<Section>();
                    Application = new ApplicationImportModel();
                    AppId = 0;
                }
            }

        }
    }
}

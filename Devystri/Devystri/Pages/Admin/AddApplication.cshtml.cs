using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;

namespace Devystri.Pages.Admin
{
#if REALESE
    [Authorize]
#endif
    public class AddApplicationModel : PageModel
    {
        [BindProperty]
        public Application Application { get; set; }
        [BindProperty]
        public List<Section> Sections { get; set; }
        [BindProperty]
        public List<Application> ListApp { get; set; }
        [BindProperty]
        public int AppId{ get; set; }

        private MyDbContext dbContext;

        public AddApplicationModel(MyDbContext context)
        {
            dbContext = context;
            ListApp = context.Applications.ToList();
        }
        public void OnGet(int id = 0)
        {
        
            if(id == 0)
            {
                Application = new Application();
                Sections = new List<Section>();
            }
            else
            {
                AppId = id;
                if (ListApp.Exists(item=> item.Id == AppId))
                {
                    
                    Application = ListApp.First(item => item.Id == AppId);
                    Sections = dbContext.Sections.Where(item => item.ProjectId == AppId).ToList();

                }
                else
                {
                    Sections = new List<Section>();
                    Application = new Application();
                    AppId = 0;
                }
            }
            
        }

        public void OnPost()
        {
            if (ListApp.Exists(item => item.Id == Application.Id))
            {
                var app = dbContext.Applications.First(item => item.Id == Application.Id);
                app.AppLogoName = Application.AppLogoName;
                app.AppStoreLink = Application.AppStoreLink;
                app.Description = Application.Description;
                app.IsOnAppStore = Application.IsOnAppStore;
                app.IsOnPlayStore = Application.IsOnPlayStore;
                app.Languages = Application.Languages;
                app.MinAge = Application.MinAge;
                app.Name = Application.Name;
                app.PlayStoreLink = Application.PlayStoreLink;
                app.PresentationRessource = Application.PresentationRessource;
                app.Stat = Application.Stat;
            }
            else
            {
                Application.Id = 0;
                dbContext.Applications.Update(Application);
            }
            _ = HttpContext.Request.Form.Files;
            UploadedFileAsync();
            dbContext.SaveChanges();
            ListApp = dbContext.Applications.ToList();
            AppId = Application.Id;
        }

        private void UploadedFileAsync()
        {
            var files = HttpContext.Request.Form.Files;
            foreach (var Image in files)
            {
                if (Image != null && Image.Length > 0)
                {

                    var file = Image;
                    var uploads = Path.Combine("", "uploads\\img\\app");

                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse
                            (file.ContentDisposition).FileName.Trim('"');

                        System.Console.WriteLine(fileName);
                        using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                            Application.AppLogoName= file.FileName;
                        }


                    }
                }
            }

        }
    }
}

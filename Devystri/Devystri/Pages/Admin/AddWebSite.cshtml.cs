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

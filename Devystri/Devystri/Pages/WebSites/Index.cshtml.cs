using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Devystri.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Devystri.Pages.Web_Sites
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public WebSites webSite { get; set; }
        public SectionLoadManage SectionLoadManage { get; set; }
        private MyDbContext dbContext;

        public IndexModel(MyDbContext context)
        {
            dbContext = context;
        }

        public IActionResult OnGet(string appName)
        {
            if (appName == String.Empty)
            {
                return RedirectToPage("Index");
            }
            else
            {
                appName = appName.ToLower();
                appName = appName.Replace("-", String.Empty);
                var listSites = dbContext.WebSites.ToList();
                if (listSites.Any(item => item.Name.ToLower().Replace(" ", String.Empty).Replace("?", String.Empty).Replace("&", String.Empty) == appName))
                {
                    webSite = listSites.First(item => item.Name.ToLower().Replace(" ", String.Empty).Replace("?", String.Empty).Replace("&", String.Empty) == appName);
                    SectionLoadManage = new SectionLoadManage(dbContext, webSite.Id, webSite.Name, "upload/websites/");
                }


            }
            return Page();

        }
    }
}

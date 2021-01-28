using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Devystri.Pages.Applications
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Application Application { get; set; }
        public List<Section> Sections { get; set; }
        private MyDbContext dbContext;
        public IndexModel(MyDbContext context)
        {
            dbContext = context;
        }
        public IActionResult OnGet(string appName)
        {
            if(appName == String.Empty)
            {
                return RedirectToPage("Index");
            }
            else
            {
                appName = appName.ToLower();
                appName = appName.Replace("-", String.Empty);
                if (dbContext.Applications.Any(item => item.Name.ToLower().Replace(" ", String.Empty) == appName))
                {
                    Application = dbContext.Applications.First(item => item.Name.ToLower().Replace(" ", String.Empty) == appName);
                    Sections = dbContext.Sections.Where(item => item.ProjectId == Application.Id).ToList();
                }

                  
            }
            return Page();
        }
    }
}

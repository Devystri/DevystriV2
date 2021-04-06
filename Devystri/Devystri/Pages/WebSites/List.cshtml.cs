using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Devystri.Pages.Web_Sites
{
    public class ListModel : PageModel
    {
        private MyDbContext dbContext;
        public List<WebSite> webSites;
        public ListModel(MyDbContext context)
        {
            dbContext = context;


        }

        public void OnGet()
        {
        
            webSites = dbContext.WebSites.ToList();
        }
    }
}

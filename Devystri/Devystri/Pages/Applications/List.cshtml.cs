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
    public class ListModel : PageModel
    {
        private MyDbContext dbContext;
        public List<Application> applications;
        public ListModel(MyDbContext context)
        {
            dbContext = context;
            foreach (var item in dbContext.Applications.ToList())
            {
                dbContext.Applications.Remove(item);

            }
            
            applications = dbContext.Applications.ToList();
        }

        public void OnGet()
        {
        }
    }
}

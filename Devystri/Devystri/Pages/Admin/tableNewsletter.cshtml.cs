using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Devystri.Pages.Admin
{
    public class TableNewsletterModel : PageModel
    {
        [BindProperty]
        public List<Newsletter> Newsletters { get; set; }
        [BindProperty]
        public int PageCount { get; set; }
        [BindProperty]
        public int ActualPage { get; set; }
        public MyDbContext dbContext;
        public TableNewsletterModel(MyDbContext context)
        {
            dbContext = context;
            
        }
        public void OnGet(int id = 1)
        {
            int numElPerPage = 15;
            ActualPage = id;
            PageCount = (dbContext.Newsletters.Count() / numElPerPage) + 1;
            Newsletters = dbContext.Newsletters.Skip((id-1)* numElPerPage).Take(numElPerPage).ToList();
        }
    }
}

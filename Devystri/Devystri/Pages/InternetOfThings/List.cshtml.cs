using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Devystri.Pages.InternetOfThings
{
    public class ListModel : PageModel
    {
        private MyDbContext dbContext;
        public List<IoT> ioTs;
        public ListModel(MyDbContext context)
        {
            dbContext = context;


        }
        public void OnGet()
        {
            ioTs = dbContext.Iots.ToList();
        }
    }
}

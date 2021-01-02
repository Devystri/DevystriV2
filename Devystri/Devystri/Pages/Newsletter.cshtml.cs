using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Devystri.Pages
{
    public class NewsletterModel : PageModel
    {
        private MyDbContext dbContext;
        private string Email = "";
        public NewsletterModel(MyDbContext context)
        {
            dbContext = context;
        }
        public void OnPost(string email)
        {
            
            int count = dbContext.Newsletters.Count(item => item.Email == email);
            if (count > 0)
            {
                return;
            }
            else
            {
                dbContext.Newsletters.Add(new Newsletter()
                {
                    Email = email,
                    Date = DateTime.Now
                });
                dbContext.SaveChanges();
            }


        }

        public void OnGet()
        {

        }
    }
        
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Devystri.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Devystri.Pages
{
    public class NewsletterModel : PageModel
    {
        [BindProperty]
        public NewsletterInputModel NewsletterInput { get; set; }
        
        private MyDbContext dbContext;
        
        public NewsletterModel(MyDbContext context)
        {
            dbContext = context;
        }
        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }
            int count = dbContext.Newsletters.Count(item => item.Email == NewsletterInput.Email);
            if (count > 0)
            {
                return;
            }
            else
            {
                dbContext.Newsletters.Add(new Newsletter()
                {
                    Email = NewsletterInput.Email,
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

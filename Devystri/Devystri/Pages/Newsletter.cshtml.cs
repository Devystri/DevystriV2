using System;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Data.Models.Statistics;
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
                DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                if(dbContext.NewsletterStats.Any(item => item.Date == today))
                {
                    dbContext.NewsletterStats.First(item => item.Date == today).Count += 1; 
                }
                else
                {
                    dbContext.NewsletterStats.Add(new NewsletterStats()
                    {
                        Count = 1,
                        Date = today
                    });
                }
                dbContext.SaveChanges();
            }


        }


    }
        
}

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

        public string Message { get; set; }

        public bool Success { get; set; }
        private MyDbContext dbContext;
        
        public NewsletterModel(MyDbContext context)
        {
            dbContext = context;
        }
        public void OnPost()
        {
            Success = false;
            if (!ModelState.IsValid)
            {
                return;
            }
            int count = dbContext.Newsletters.Count(item => item.Email == NewsletterInput.Email);
            if (count > 0)
            {
                Message = "Cette adresse email est déjà inscrite à la newsletter.";
                return;
            }
            else
            {
                try
                {
                    dbContext.Newsletters.Add(new Newsletter()
                    {
                        Email = NewsletterInput.Email,
                        Date = DateTime.Now
                    });
                    DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    if (dbContext.NewsletterStats.Any(item => item.Date == today))
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
                    Message = "Adresse email ajoutée avec succès.";
                    Success = true;
                }
                catch (Exception)
                {
                    Success = false;
                    Message = "Impossible d'ajouter cette adresse email pour une raison inconnue, veuillez nous contacter afin de signaler cette erreur.";
                }
                
            }


        }


    }
        
}

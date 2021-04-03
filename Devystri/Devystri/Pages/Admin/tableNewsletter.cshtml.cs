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
        public int PageCount { get; set; }
        public int ActualPage { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

        private MyDbContext dbContext;

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
        public IActionResult OnPost(int id)
        {
            Success = false;

            var req = HttpContext.Request.Form;
            try
            {
                if (dbContext.Newsletters.Any(item => item.Id == id))
                {
                    dbContext.Newsletters.Remove(new Newsletter() { Id = id });
                    dbContext.SaveChanges();
                    Success = true;
                    Message = "Adresse email supprimée avec succès.";
                }
                else
                {
                    Message = "Cette adresse email n'existe pas.";

                }



            }
            catch (Exception ex)
            {
                Message = "Impossible de supprimer cette adresse email.";
            }
          

            return RedirectToPage("/Admin/tableNewsletter");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Devystri.Pages.Admin
{
#if RELEASE
    [Authorize]
#endif
    public class DeleteSectionModel : PageModel
    {
        private MyDbContext dbContext { get; set; }

        public DeleteSectionModel(MyDbContext context)
        {
            dbContext = context;
        }
        public void OnGet(int id)
        {
            if(dbContext.Sections.Any(item => item.Id == id))
            {
                try
                {
                    dbContext.Sections.Remove(dbContext.Sections.FirstOrDefault(item => item.Id == id));
                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Impossible to delete the section from the id: " + id + ". See the innerExeption", ex);
                }
                
            }
        }
    }
}

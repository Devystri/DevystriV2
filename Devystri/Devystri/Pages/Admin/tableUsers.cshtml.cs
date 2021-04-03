using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Devystri.Pages.Admin
{
#if RELEASE
    [Authorize]
#endif
    public class tableUsersModel : PageModel
    {
        [BindProperty]
        public List<AdminUser> Users { get; set; }
        [BindProperty]
        public int PageCount { get; set; }
        [BindProperty]
        public int ActualPage { get; set; }
        public IdentityAppContext dbContext;
        public tableUsersModel(IdentityAppContext context)
        {
            dbContext = context;

        }
        public void OnGet(int id = 1)
        {
            int numElPerPage = 15;
            ActualPage = id;
            PageCount = (dbContext.Users.Count() / numElPerPage) + 1;
            Users = dbContext.Users.Skip((id - 1) * numElPerPage).Take(numElPerPage).ToList();
        }
        public IActionResult OnPost(int id)
        {
            var req = HttpContext.Request.Form;
            if (dbContext.Users.Any(item => item.Id == id))
            {
                dbContext.Users.Remove(new AdminUser() { Id = id });
                dbContext.SaveChanges();
            }


            return RedirectToPage("/Admin/tableUsers");
        }
    }
}

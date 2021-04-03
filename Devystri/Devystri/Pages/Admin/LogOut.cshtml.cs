using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Devystri.Pages.Admin
{
#if REALESE
    [Authorize]
#endif
    public class LogOutModel : PageModel
    {
        public LogOutModel(SignInManager<AdminUser> signInManager)
        {
            signInManager.SignOutAsync();
        }
        public IActionResult OnGet()
        {
            return RedirectToPage("/Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models.Entity;
using Devystri.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Devystri.Pages.Admin
{
#if RELEASE
    [Authorize]
#endif
    public class ChangePasswordModel : PageModel
    {
        [BindProperty]
        public ChangePasswordInputModel changePasswordInput { get; set; }
        private UserManager<AdminUser> UserManager;

        public ChangePasswordModel(UserManager<AdminUser> userManager)
        {
            UserManager = userManager;
        }

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(changePasswordInput.NewPassword == changePasswordInput.NewPasswordConfirm)
            {
                var user = await UserManager.FindByEmailAsync(changePasswordInput.Email.ToUpper());
                var result = await UserManager.ChangePasswordAsync(user, changePasswordInput.Password, changePasswordInput.NewPassword);
                if (result.Succeeded)
                {
                    return RedirectToPage("Login");
                }
            }
           
            return Page();
        }
    }
}

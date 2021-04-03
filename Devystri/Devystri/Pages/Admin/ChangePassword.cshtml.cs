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
        public string Message { get; set; }
        public bool Success { get; set; }

        private UserManager<AdminUser> UserManager;

        public ChangePasswordModel(UserManager<AdminUser> userManager)
        {
            UserManager = userManager;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Success = false;

            if (changePasswordInput.NewPassword == changePasswordInput.NewPasswordConfirm)
            {
                var user = await UserManager.FindByEmailAsync(changePasswordInput.Email.ToUpper());
                if(user is null)
                {
                    Message = "Cet utilisateur n'existe pas.";
                }
                var result = await UserManager.ChangePasswordAsync(user, changePasswordInput.Password, changePasswordInput.NewPassword);
                if (result.Succeeded)
                {
                    Success = true;
                    return RedirectToPage("Login");
                }
                else
                {
                    Message = "Impossible de changer le mot de passe pour la/les raisons suivantes:";
                    foreach (var error in result.Errors)
                    {
                        Message += "</br>" + " - " + error; 
                    }

                }
            }
            else
            {
                Message = "La comfirmation du mot de passe ne correspond pas au mot de passe.";

            }

            return Page();
        }
    }
}

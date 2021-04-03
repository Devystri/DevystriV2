using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Devystri.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Data.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Devystri.Pages.Admin
{

    public class LoginModel : PageModel
    {
        private SignInManager<AdminUser> SignInManager;

        [BindProperty]
        public LoginInputModel Login { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }


        public LoginModel( SignInManager<AdminUser> signInManager)
        {
            SignInManager = signInManager;

        }


        public async Task<IActionResult> OnPostAsync()
        {
            SignInResult result;
            try
            {
                result = await SignInManager.PasswordSignInAsync(Login.Email, Login.Password, false, true);

            }
            catch (Exception)
            {
                Success = false;
                Message = "Impossible de se connecter pour une erreur inconnue.";
                return Page();
            }

            if (result.Succeeded)
            {
                Success = true;
                return RedirectToPage("/admin/dashboard");
            }
            else
            {
                Success = false;
                Message = "Les identifiants ne correspondent pas.";
            }
            
            
            return Page();
        }

      
    }
}

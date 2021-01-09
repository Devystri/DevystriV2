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
using Modules;
using Microsoft.AspNetCore.Identity;
using Data.Models.Entity;
using Microsoft.AspNetCore.Authorization;

namespace Devystri.Pages.Admin
{
    public class LoginModel : PageModel
    {
        private MyDbContext myDbContext;
        public string Message;
        private SignInManager<AdminUser> SignInManager;

        [BindProperty]
        public LoginInputModel Login { get; set; }

        public LoginModel(MyDbContext context, SignInManager<AdminUser> signInManager)
        {
            SignInManager = signInManager;
            myDbContext = context;

        }
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var result = await SignInManager.PasswordSignInAsync(Login.Email, Login.Password, false, true);
            if (result.Succeeded)
            {
                return RedirectToPage("/admin/dashboard");
            }
            
            return Page();
        }

      
    }
}

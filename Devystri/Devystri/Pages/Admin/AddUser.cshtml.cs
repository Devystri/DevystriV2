using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Data.Models.Entity;
using Devystri.Model.Admin;
using Data;
using Microsoft.AspNetCore.Authorization;

namespace Devystri.Pages.Admin
{
#if REALESE
    [Authorize]
#endif
    public class AddUserModel : PageModel
    {
        [BindProperty]
        public NewAccountInput AccountInput { get; set; }
        public string Message { get; set; }
        private UserManager<AdminUser> UserManager { get; set; }

        public AddUserModel(UserManager<AdminUser> userManager)
        {
            UserManager = userManager;


        }

        public async Task OnPost()
        {

            if(AccountInput.ComfirmationPassword != AccountInput.Password)
            {
                return;
            }
            await CreateUser();
        }

        public async Task<bool> CreateUser()
        {
            if (await UserManager.FindByEmailAsync(AccountInput.Email) is not null)
            {
                Message = "L'adresse email " + AccountInput.Email +  " existe déjà.";
                return false;
            }
            IdentityResult result;
            try
            {
                result = await UserManager.CreateAsync(new AdminUser()
                {
                    Email = AccountInput.Email,
                    FirstName = AccountInput.UserName,
                    LastName = AccountInput.UserName,
                    UserName = AccountInput.Email
                }, AccountInput.Password);
            }
            catch(Exception e)
            {
                throw new Exception("The user can't be added. Check the innerExeption.", e);
            }
           


            if (result.Succeeded)
            {
                Message = AccountInput.UserName + " a été ajouté avec succès.";
                return true;
            }
            else
            {
                Message = AccountInput.UserName + " n'a pas pu être ajouté pour les raisons suivantes:";
                foreach (var error in result.Errors)
                {
                    Message += @"<br/>  - " + error.Description;
                }

                return false;
            }
        }
    }
}

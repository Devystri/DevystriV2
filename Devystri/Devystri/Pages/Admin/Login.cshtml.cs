using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modules;

namespace Devystri.Pages.Admin
{
    public class LoginModel : PageModel
    {
        private MyDbContext myDbContext;
        public string Message;
        public LoginModel(MyDbContext context)
        {
            myDbContext = context;
#if DEBUG
            if(context.Users.Where(item => item.Email == "dev@devystri.com").Count() < 1)
            {
                context.Users.Add(new User()
                {
                    Email = "dev@devystri.com",
                    FirstName = "Developper",
                    Name = "Name",
                    Password = PasswordHasher.HashPassword("password"),
                    CreationDateTime = DateTime.Now,
                    LastUpdateDateTime = DateTime.Now

                });
                context.SaveChanges();
            }
     
#endif
        }
        public void OnGet()
        {
            
        }

        public IActionResult OnPost(string email, string password )
        {

            List<User> users = myDbContext.Users.Where(item => item.Email == email).ToList();
            if(users.Count < 1)
            {
                Message = "Les identifiants ne correspondent pas ou le compte n'existe pas.";
            }
            else if(users.Count > 1)
            {
                Message = "Connexion impossible.";
            }
            else if(users.Count == 1)
            {
                if (PasswordHasher.VerifyPassword(users[0].Password, password))
                {
                    Message = "Connecté avec succés.";
                  
                    HttpContext.Session.Set(KeySaver.KEY_CONNED_SESSION, BitConverter.GetBytes(true));
                    BitConverter.ToBoolean(HttpContext.Session.Get(KeySaver.KEY_CONNED_SESSION));
                    return Redirect("/admin/dashboard");
                }
            }
            return Page();
        }
    }
}

using Data;
using Data.Models;
using Data.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Devystri.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private MyDbContext myDbContext;

        public IndexModel(ILogger<IndexModel> logger, MyDbContext context, UserManager<AdminUser> userManager)
        {
#if DEBUG
            _ = Register(userManager);
#endif
            if (context != null)
            {
                myDbContext = context;
            }   

            _logger = logger;
        }
        private async Task Register(UserManager<AdminUser> userManager)
        {
            await userManager.CreateAsync(new AdminUser()
            {
                Email = "dev@devystri.com",
                FirstName = "Develpper",
                LastName = "Debug",
                UserName = "dev@devystri.com"
            }, "Password1234!");
        }
        public void OnGet()
        {

        }
    }
}

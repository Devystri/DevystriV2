using Data;
using Data.Models;
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

        public IndexModel(ILogger<IndexModel> logger, MyDbContext context)
        {
            myDbContext = context;
            //myDbContext.Users.Add(new UserGroup() { Email = "dimitri.timoz@orange.fr", Password = "test" });
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models.Statistics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Devystri.Pages.Admin
{

#if RELEASE
    [Authorize]
#endif
    public class DashboardModel : PageModel
    {
        [BindProperty]
        public List<OSStats> oSStats { get; set; }
        public List<NewsletterStats> NewsletterStats { get; set; }

        private MyDbContext dbContext;
        public DashboardModel(MyDbContext context)
        {
            dbContext = context;
            oSStats = dbContext.OSs.ToList();
            NewsletterStats = dbContext.NewsletterStats.ToList();

        }
        public void OnGet()
        {
       
        }

       
    }
}

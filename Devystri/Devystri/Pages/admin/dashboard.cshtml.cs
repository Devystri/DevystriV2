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
        public int ContactInWeek{ get; set; }

        private MyDbContext dbContext;
        public DashboardModel(MyDbContext context)
        {
            dbContext = context;
            oSStats = dbContext.OSs.ToList();
            NewsletterStats = dbContext.NewsletterStats.ToList();
            TimeSpan sevenDay = new TimeSpan(7, 0, 0, 0, 0);
            DateTime lastWeek = DateTime.Now - sevenDay;
            
            if (dbContext.ContactStats.Any(item =>  item.Date > lastWeek))
            {
                var ofWek = dbContext.ContactStats.Where(item => item.Date > lastWeek   ).ToList();

                ContactInWeek = ofWek.Sum(item => item.Count);
            }
 

        }
        public void OnGet()
        {
       
        }

       
    }
}

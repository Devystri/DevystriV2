using Data;
using Data.Models.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Statistics
{
    public static class PageCounter
    {
        public static async Task CountPage(MyDbContext context, int pageId)
        {
            DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var visitCount = context.Visits.FirstOrDefault(item => item.Date == today && item.Page == pageId);
            if(visitCount == null)
            {
                await context.Visits.AddAsync(new Visits()
                {
                    Count = 1,
                    Page = pageId,
                    Date = today
                });

            }
            else
            {
                visitCount.Count++;
                context.Visits.Update(visitCount);
            }

            await context.SaveChangesAsync();
        }
    }
}

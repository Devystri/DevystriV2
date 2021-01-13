using Data;
using Data.Models.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Devystri
{
    public static class PageCounter
    {
        private static Task GetRouteUrlWithAuthorizeAttribute()
        {

            var components = Assembly.GetExecutingAssembly()
                                   .GetExportedTypes();

            foreach (var component in components)
            {
                if (component.FullName.Contains("Devystri.Pages"))
                {
                    string name = component.FullName.Replace("Model", String.Empty).Replace("Devystri.Pages", String.Empty).Replace(".", "/").Replace("_", "-").ToLower();
                    Console.WriteLine(name);
                }
            }

            return Task.CompletedTask;
        }
        public static async Task CountPage(MyDbContext context, int pageId)
        {
            DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var visitCount = context.Visits.FirstOrDefault(item => item.Date == today && item.Page == pageId);
            GetRouteUrlWithAuthorizeAttribute();
            if (visitCount == null)
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

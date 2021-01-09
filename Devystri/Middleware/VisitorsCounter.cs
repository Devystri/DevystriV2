using Data;
using Data.Models.Statistics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware
{
    public class VisitorsCounter
    {
        private readonly RequestDelegate _requestDelegate;

        public VisitorsCounter(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context, MyDbContext dbContext)
        {
            var path = context.Request.Path.Value.ToLower();
            if(context.Request.Method == "GET" && !path.Contains('.'))
            {
                var now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                var newCount = dbContext.Visits.FirstOrDefault(item => item.Date == now);

                if (newCount != null)
                {
                    newCount.Count++;
                    dbContext.Visits.Update(newCount);
                }
                else
                {
                    dbContext.Visits.Add(new Visits()
                    {
                        Count = 1,
                        Date = now,
                        Page = 0
                    });
                }

                dbContext.SaveChanges();
                context.Response.Cookies.Append("VisitorId", Guid.NewGuid().ToString(), new CookieOptions()
                {
                    Path = "/",
                    HttpOnly = true,
                    Secure = false,
                });
            }
            
            
               
            

            await _requestDelegate(context);
        }
    }
}

using Data;
using Data.Models.Statistics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        private OSPlatform GetOSPlatform()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return OSPlatform.Windows;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return OSPlatform.Linux;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return OSPlatform.OSX;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD))
            {
                return OSPlatform.FreeBSD;
            }
            else if (RuntimeInformation.OSDescription.ToLower().Contains("android"))
            {
                return OSPlatform.Create("Android");
            }
            else if (RuntimeInformation.OSDescription.ToLower().Contains("ios"))
            {
                return OSPlatform.Create("IOS");
            }
            else 
            {
                return OSPlatform.Create("Other");
            }

        }
        public async Task InvokeAsync(HttpContext context, MyDbContext dbContext)
        {
            var path = context.Request.Path.Value.ToLower();
            if(context.Request.Method == "GET" && !path.Contains('.'))
            {
                if(context.Request.Cookies.Keys.Any(item => item == "VisitorId"))
                {
                    await _requestDelegate(context);
                    return;
                }
        
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
                var os =  GetOSPlatform().ToString();
                if(dbContext.OSs.Any(item => item.OsName == os))
                {
                    dbContext.OSs.First(item => item.OsName == os).Counts += 1;
                }
                else
                {
                    dbContext.OSs.Add(new OSStats()
                    {
                        Counts = 1,
                        OsName = os,
                        OsId = 0
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

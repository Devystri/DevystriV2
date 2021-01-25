using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using Data.Models;
using Data.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Middleware;

namespace Devystri
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            services.AddIdentity<AdminUser, ApplicationRoles>(options =>
            {
                options.User.RequireUniqueEmail = true;

            }).AddEntityFrameworkStores<IdentityAppContext>();

            
            try
            {
                services.AddDbContextPool<MyDbContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));
                services.AddDbContextPool<IdentityAppContext>(cfg =>
                {
                    cfg.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr));
                });

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            services.AddDistributedMemoryCache();

            services.AddRazorPages().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/admin/Login", "/admin/*"); 
                options.Conventions.AddPageRoute("/Admin/ChangePassword", "/admin/change-password"); 
                options.Conventions.AddPageRoute("/Admin/AddApplication", "/admin/manage-application"); 
        
            });

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
                
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/admin/login";
                options.AccessDeniedPath = "/admin/login";
                options.SlidingExpiration = true;
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            var options = new StaticFileOptions
            {
                ContentTypeProvider = new FileExtensionContentTypeProvider()
            };
            ((FileExtensionContentTypeProvider)options.ContentTypeProvider).Mappings.Add(
                new KeyValuePair<string, string>(".glb", "text/plain"));

            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseMiddleware(typeof(VisitorsCounter));
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404 || context.Response.StatusCode == 500)
                {
                    context.Request.Path = "/Error/404";
                    await next();
                }
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles(options);

            app.UseRouting();

            app.UseAuthentication();
#if RELEASE
            app.UseAuthorization();
#endif
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Devystri.Pages.Applications
{
    public class ListModel : PageModel
    {
        private MyDbContext dbContext;
        public List<Application> applications;
        public ListModel(MyDbContext context)
        {
            dbContext = context;
            foreach (var item in dbContext.Applications.ToList())
            {
                dbContext.Applications.Remove(item);

            }
            
            dbContext.Applications.Add(new Application()
            {
                Name = "Motivation",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras mollis lorem odio, et vestibulum mi bibendum in. Interdum et malesuada fames ac ante ipsum primis in faucibus. Aenean sodales nibh vel felis hendrerit, ac luctus felis accumsan. Vivamus vitae elit commodo, lacinia elit ut, porttitor felis. In magna lorem, malesuada ut vehicula vel, gravida ac mauris.",
                IsOnAppStore = 1,
                IsOnPlayStore = 1,
                AppLogoName = "motivation-logo.png",
                PresentationRessource = "application-image-motivation.png",
                Stat = (int)Stats.CANCEL
            });

            dbContext.Applications.Add(new Application()
            {
                Name = "HomeConnect",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras mollis lorem odio, et vestibulum mi bibendum in. Interdum et malesuada fames ac ante ipsum primis in faucibus. Aenean sodales nibh vel felis hendrerit, ac luctus felis accumsan. Vivamus vitae elit commodo, lacinia elit ut, porttitor felis. In magna lorem, malesuada ut vehicula vel, gravida ac mauris.",
                IsOnAppStore = 0,
                IsOnPlayStore = 1,
                AppLogoName = "Logo-HomeConnect.svg",
                PresentationRessource = "application-image-HomeConnect.png",
                Stat = (int)Stats.NOT_DOWNLABLE
            });
            dbContext.SaveChanges();
            applications = dbContext.Applications.ToList();
        }

        public void OnGet()
        {
        }
    }
}

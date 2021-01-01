using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Devystri.Pages.Web_Sites
{
    public class ListModel : PageModel
    {
        private MyDbContext dbContext;
        public List<WebSites> webSites;
        public ListModel(MyDbContext context)
        {
            dbContext = context;
            foreach (var item in dbContext.WebSites.ToList())
            {
                dbContext.WebSites.Remove(item);
            }
            context.Add(new WebSites()
            {
                Name = "What Is It ?",
                AppLogoName = "Logo-whatIsIt.svg",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras mollis lorem odio, et vestibulum mi bibendum in. Interdum et malesuada fames ac ante ipsum primis in faucibus. Aenean sodales nibh vel felis hendrerit, ac luctus felis accumsan. Vivamus vitae elit commodo, lacinia elit ut, porttitor felis. In magna lorem, malesuada ut vehicula vel, gravida ac mauris.",
                Link = "http://what-is-it.fr/",
                PresentationRessource = "WhatIsItMacbook.png",
                Stat = (int)Stats.CANCEL
            });
            context.SaveChanges();
            webSites = context.WebSites.ToList();

        }
        public void OnGet()
        {
        }
    }
}

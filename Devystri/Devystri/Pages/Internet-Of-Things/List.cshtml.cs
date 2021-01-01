using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Devystri.Pages.Internet_Of_Things
{
    public class ListModel : PageModel
    {
        private MyDbContext dbContext;
        public List<IoT> ioTs;
        public ListModel(MyDbContext context)
        {
            dbContext = context;
            foreach (var item in dbContext.Iots.ToList())
            {
                dbContext.Iots.Remove(item);
            }
            context.Add(new IoT()
            {
                Name = "HomeConnect",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras mollis lorem odio, et vestibulum mi bibendum in. Interdum et malesuada fames ac ante ipsum primis in faucibus. Aenean sodales nibh vel felis hendrerit, ac luctus felis accumsan. Vivamus vitae elit commodo, lacinia elit ut, porttitor felis. In magna lorem, malesuada ut vehicula vel, gravida ac mauris.",
                PresentationRessource = "WhatIsItMacbook.png",
                Stat = (int)Stats.CANCEL
            });
            context.SaveChanges();
            ioTs = context.Iots.ToList();

        }
        public void OnGet()
        {
        }
    }
}

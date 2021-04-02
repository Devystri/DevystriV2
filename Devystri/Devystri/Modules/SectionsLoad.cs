using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Devystri.Modules
{
    public class SectionsLoad
    {
        [BindProperty]
        public List<Section> Sections { get; set; }
        public string Name { get; set; }

        public SectionsLoad(MyDbContext context, int id, string name)
        {
            if (id == 0)
            {
                return;
            }
            else
            {
                Name = name;
                var sections = context.Sections.ToList();
                if (sections.Any(item => item.ProjectId == id))
                {
                    Sections = sections.Where(item => item.ProjectId == id).ToList();
                }


            }
        }
    }
}

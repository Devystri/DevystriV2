using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Devystri.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Devystri.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public ContactInputForm ContactInputForm { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
           
     
        }

      
    
    }
}

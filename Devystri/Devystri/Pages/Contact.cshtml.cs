using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Devystri.Pages
{
    public class ContactModel : PageModel
    {
        public string Message;
        public void OnGet()
        {
        }

        public void OnPost(string name, string firstname, string email, string obj, string message)
        {
            if(name == String.Empty)
            {
                return;
            }
            if (firstname == String.Empty)
            {
                return;
            }
            if (email == String.Empty)
            {
                return;
            }
            if (obj == String.Empty)
            {
                return;
            }
            if (message == String.Empty)
            {
                return;
            }
     
        }

      
    
    }
}

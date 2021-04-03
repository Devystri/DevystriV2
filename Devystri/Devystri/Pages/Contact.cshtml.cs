using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Data;
using Data.Models.Statistics;
using Devystri.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Devystri.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public ContactInputForm ContactInputForm { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

        private MyDbContext dbContext { get; set; }

        public ContactModel(MyDbContext context)
        {
            dbContext = context;
        }


        public void OnPost()
        {
            Success = false;
            var fromAddress = new MailAddress("sender@devystri.com", ContactInputForm.Name + " " + ContactInputForm.FirstName);
            var toAddress = new MailAddress("contact@devystri.com", "Devystri Contact");
            const string fromPassword = "z-5@TQ)T7Y){";

            if (!ModelState.IsValid)
            {
                Message = "Tous les champs de saisie ne sont pas correctement remplis.";
                return;
            }

            var smtp = new SmtpClient
            {
                Host = "mail.devystri.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = ContactInputForm.Subject,
                Body = "Mail de: " + ContactInputForm.Email +"\n\n"+ ContactInputForm.Message
            })
            {
                try
                {
                    smtp.Send(message);
                    Success = true;
                    Message = "Email envoyé avec succès.";
                    _ = UpdateContactStats(ContactInputForm.Email);
                }
                catch (Exception)
                {
                    Message = "Cet email n'a pas pu être envoyé pour une raison inconnue, veuillez nous contacter à l'adresse: contact@devystri.com";

                }
            }
        }

      
        private async Task UpdateContactStats(string email)
        {
            email = email.ToLower();
            DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            if(dbContext.ContactStats.Any(item => item.Email == email && item.Date == today))
            {
                dbContext.ContactStats.First(item => item.Email == email && item.Date == today).Count += 1;
            }
            else
            {
                dbContext.ContactStats.Add(new ContactStats()
                {
                    Count = 1,
                    Email = email,
                    Date = today
                });
            }
            await dbContext.SaveChangesAsync();
            return;
        }
    }
}

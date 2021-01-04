using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    public class EmailSender
    {
        static bool mailSent = false;
        private  void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
             String token = (string) e.UserState;

            if (e.Cancelled)
            {
                 Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                 Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            } else
            {
                Console.WriteLine("Message sent.");
            }
            mailSent = true;
        }
        public EmailSender(string email, string obj, string name, string msg )
        {
            // Command-line argument must be the SMTP host.
            SmtpClient client = new SmtpClient("mail.devystri.com", 645);
            var credentialsByHost = new NetworkCredential("sender@devystri.com", "_uSnW;yqJ#_D", "mail.devystri.com");
            client.UseDefaultCredentials = false;
            client.Credentials = credentialsByHost;
            client.EnableSsl = true;

            // Specify the email sender.
            // Create a mailing address that includes a UTF8 character
            // in the display name.
            MailAddress from = new MailAddress("sender@devystri.com",
               name,
            System.Text.Encoding.UTF8);
            // Set destinations for the email message.
            MailAddress to = new MailAddress("contact@devystri.com");
            // Specify the message content.
            MailMessage message = new MailMessage(from, to);
            message.Body = msg;

            message.Body += Environment.NewLine + "Ce message a été envoyé via le formulaire de contact de devystri.com";
            message.BodyEncoding =  System.Text.Encoding.UTF8;
            message.Subject = obj;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            // Set the method that is called back when the send operation ends.
            client.SendCompleted += new
            SendCompletedEventHandler(SendCompletedCallback);
            // The userState can be any object that allows your callback
            // method to identify this send operation.
            // For this example, the userToken is a string constant.
            string userState = "test message1";
            client.SendAsync(message, userState);
           
            // Clean up.
            //message.Dispose();
            Console.WriteLine("Goodbye.");
        }
    }
}

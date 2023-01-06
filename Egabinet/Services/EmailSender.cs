using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace Egabinet.Services
{

    public class EmailSender : IEmailSender
    {
        /*        string email = "email";
                string subject = "subject";
                string htmlMessage = "ddddd";*/
        public EmailSender()
        {


        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            SmtpClient client = new SmtpClient
            {
                Port = 587,
                Host = "smtp.gmail.com", //or another email sender provider
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("emailsenderegabinet@gmail.com", "feeaadbbfdawxxpv")
            };

            var message = new MailMessage("emailsenderegabinet@gmail.com", email, subject, htmlMessage);
            message.IsBodyHtml = true;

            return client.SendMailAsync(message);
        }
    }
}


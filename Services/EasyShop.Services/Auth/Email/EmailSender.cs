//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity.UI.Services;
//using Microsoft.Extensions.Options;
//using SendGrid;
//using SendGrid.Helpers.Mail;

//namespace EasyShop.Services.Auth.Email
//{
//    public class EmailSender : IEmailSender
//    {
//        private readonly string _apiKey;
//        public EmailSender()
//        {
//            _apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
//        }
//        public Task SendEmailAsync(string email, string subject, string message)
//        {
//            return Execute(_apiKey, subject, message, email);
//        }

//        private Task Execute(string apiKey, string subject, string message, string email)
//        {
//            var client = new SendGridClient(apiKey);
//            var msg = new SendGridMessage
//            {
//                From = new EmailAddress("aleksejs.birula.corporation@gmail.com"),
//                Subject = subject,
//                PlainTextContent = message,
//                HtmlContent = message
//            };
//            msg.AddTo(new EmailAddress(email));

//            // Disable click tracking.
//            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
//            msg.SetClickTracking(false, false);

//            return client.SendEmailAsync(msg);
//        }
//    }
//}

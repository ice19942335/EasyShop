using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace EasyShop.Services.Email
{
    /// <summary>
    /// Sending email trough sendgrid.com
    /// </summary>
    public class EmailSender : IEmailSender
    {
        public IConfiguration Configuration { get; }
        private readonly string _apiKey;

        public EmailSender(IConfiguration configuration)
        {
            Configuration = configuration;
            _apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        }

        public Task SendEmailAsync(string email, string subject, string message) => Execute(_apiKey, subject, message, email);

        private Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage
            {
                From = new EmailAddress(Configuration["SendGridSenderEmail"]),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}

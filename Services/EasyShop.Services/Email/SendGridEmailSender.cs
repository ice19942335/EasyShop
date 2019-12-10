using System;
using System.Threading.Tasks;
using EasyShop.Interfaces.Email;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace EasyShop.Services.Email
{
    /// <summary>
    /// Sending email trough sendgrid.com
    /// </summary>
    public class SendGridEmailSender : ISendGridEmailSender
    {
        public IConfiguration Configuration { get; }
        private readonly string _apiKey;

        public SendGridEmailSender(IConfiguration configuration)
        {
            Configuration = configuration;
            _apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        }

        public Task<Response> SendEmailAsync(string email, string subject, string message) => Execute(_apiKey, subject, message, email);

        private Task<Response> Execute(string apiKey, string subject, string message, string email)
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

            var result = client.SendEmailAsync(msg);

            return result;
        }
    }
}

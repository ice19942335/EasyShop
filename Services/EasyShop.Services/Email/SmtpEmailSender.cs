using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using EasyShop.Domain.Settings;
using EasyShop.Interfaces.Email;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;


namespace EasyShop.Services.Email
{
    public class SmtpEmailSender : ISmtpEmailSender
    {
        public SmtpEmailSender(IOptions<GmailSmtpSettings> emailSettings)
        {
            EmailSettings = emailSettings.Value;
        }

        public GmailSmtpSettings EmailSettings { get; }

        public async Task<bool> SendEmailAsync(string email, string subject, string message)
        {

            return await Execute(email, subject, message);
            //return Task.FromResult(0);
        }

        public async Task<bool> Execute(string email, string subject, string message)
        {
            try
            {
                string toEmail = string.IsNullOrEmpty(email)
                    ? EmailSettings.ToEmail
                    : email;
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(EmailSettings.UsernameEmail, "Game Server Monetization")
                };
                mail.To.Add(new MailAddress(toEmail));
                mail.CC.Add(new MailAddress(EmailSettings.CcEmail));

                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(EmailSettings.PrimaryDomain, EmailSettings.PrimaryPort))
                {
                    smtp.Credentials = new NetworkCredential(EmailSettings.UsernameEmail, EmailSettings.UsernamePassword);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}

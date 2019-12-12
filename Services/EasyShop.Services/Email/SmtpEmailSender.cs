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
        private readonly GmailSmtpSettings _smtpSettings;

        public SmtpEmailSender(GmailSmtpSettings smtpSettings)
        {
            _smtpSettings = smtpSettings;
        }

        public async Task<bool> SendEmailAsync(string email, string subject, string message)
        {

            return await Execute(email, subject, message);
            //return Task.FromResult(0);
        }

        public async Task<bool> Execute(string email, string subject, string message)
        {
            try
            {
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(_smtpSettings.UsernameEmail, "Game Server Monetization")
                };
                mail.To.Add(new MailAddress(email));
                mail.CC.Add(new MailAddress(_smtpSettings.CcEmail));

                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(_smtpSettings.PrimaryDomain, _smtpSettings.PrimaryPort))
                {
                    smtp.Credentials = new NetworkCredential(_smtpSettings.UsernameEmail, _smtpSettings.UsernamePassword);
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

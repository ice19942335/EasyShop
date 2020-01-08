using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Settings;
using EasyShop.Interfaces.Email;
using EasyShop.Services.ExtensionMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;


namespace EasyShop.Services.Email
{
    public class SmtpEmailSender : ISmtpEmailSender
    {
        private readonly GmailSmtpSettings _smtpSettings;
        private readonly ILogger<SmtpEmailSender> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public SmtpEmailSender(GmailSmtpSettings smtpSettings, ILogger<SmtpEmailSender> logger, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _smtpSettings = smtpSettings;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<bool> SendEmailAsync(string email, string subject, string message)
        {
            return await Execute(email, subject, message);
        }

        public async Task<bool> Execute(string email, string subject, string message)
        {
            var userForLog = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name ?? "Null");

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

                using SmtpClient smtp = new SmtpClient(_smtpSettings.PrimaryDomain, _smtpSettings.PrimaryPort);
                smtp.Credentials = new NetworkCredential(_smtpSettings.UsernameEmail, _smtpSettings.UsernamePassword);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mail);

                
                _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                    userForLog != null ? userForLog.UserName : "Null",
                    userForLog != null ? userForLog.Id : "Null",
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    $"Mail has been sent to receiver: {email}; Subject: {subject}; PostMessage: {message};");

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                    userForLog != null ? userForLog.UserName : "Null",
                    userForLog != null ? userForLog.Id : "Null",
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    $"Error on sending email. Error: {e.Message}; Inner exception: {e.InnerException?.Message}; Stacktrace:\n{e.StackTrace};");

                return false;
            }
        }
    }
}

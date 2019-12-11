using System;
using System.Net;
using System.Threading.Tasks;
using EasyShop.Domain.Settings;
using EasyShop.Interfaces.Email;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;


namespace EasyShop.Services.Email
{
    public class SmtpEmailSender : ISmtpEmailSender
    {
        private readonly SmtpEmailSettings _emailSettings;
        private readonly IWebHostEnvironment _env;

        public SmtpEmailSender(SmtpEmailSettings emailSettings, IWebHostEnvironment env)
        {
            _emailSettings = emailSettings;
            _env = env;
        }


        public async Task<bool> SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var mimeMessage = new MimeMessage();

                mimeMessage.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.Sender));

                mimeMessage.To.Add(new MailboxAddress(email));

                mimeMessage.Subject = subject;

                mimeMessage.Body = new TextPart("html")
                {
                    Text = message
                };

                using var client = new SmtpClient();
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                if (_env.IsDevelopment())
                {
                    // The third parameter is useSSL (true if the client should make an SSL-wrapped
                    // connection to the server; otherwise, false).
                    await client.ConnectAsync(_emailSettings.MailServer, _emailSettings.MailPort, false);
                }
                else
                {
                    await client.ConnectAsync(_emailSettings.MailServer);
                }

                // Note: only needed if the SMTP server requires authentication
                await client.AuthenticateAsync(_emailSettings.Sender, _emailSettings.Password);

                await client.SendAsync(mimeMessage);

                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                // TODO: handle exception
                //throw new InvalidOperationException(ex.Message);

                return false;
            }

            return true;
        }
    }
}

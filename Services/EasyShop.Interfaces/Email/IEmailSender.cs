using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SendGrid;

namespace EasyShop.Interfaces.Email
{
    public interface IEmailSender
    {
        Task<Response> SendEmailAsync(string email, string subject, string message);
    }
}

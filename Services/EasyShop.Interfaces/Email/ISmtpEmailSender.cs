using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyShop.Interfaces.Email
{
    public interface ISmtpEmailSender
    {
        Task<bool> SendEmailAsync(string email, string subject, string message);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Enums;

namespace EasyShop.Domain.Settings
{
    public class SendGridSmtpSettings
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
    }
}

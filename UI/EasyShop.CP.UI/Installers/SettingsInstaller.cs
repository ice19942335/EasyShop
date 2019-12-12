using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyShop.CP.UI.Installers
{
    public class SettingsInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("SendGridSmtpSettings").Get<SendGridSmtpSettings>());

            services.AddSingleton(configuration.GetSection("GmailSmtpSettings").Get<GmailSmtpSettings>());

            services.Configure<GmailSmtpSettings>(configuration.GetSection("GmailSmtpSettings"));
        }
    }
}

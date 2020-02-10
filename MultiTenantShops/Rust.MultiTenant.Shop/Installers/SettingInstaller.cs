using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using EasyShop.Domain.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Rust.MultiTenant.Shop.Installers
{
    public class SettingInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("PayPalSettings").Get<PayPalSettings>());




            //Samples
            //services.Configure<GmailSmtpSettings>(configuration.GetSection("GmailSmtpSettings"));
            //services.AddSingleton(configuration.GetSection("ImgurSettings").Get<ImgurSettings>());
        }
    }
}

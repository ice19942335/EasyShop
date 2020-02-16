using EasyShop.Domain.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ServerMonetization.CP.Installers
{
    public class SettingsInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("SendGridSmtpSettings").Get<SendGridSmtpSettings>());

            services.AddSingleton(configuration.GetSection("GmailSmtpSettings").Get<GmailSmtpSettings>());

            services.Configure<GmailSmtpSettings>(configuration.GetSection("GmailSmtpSettings"));

            services.AddSingleton(configuration.GetSection("ImgurSettings").Get<ImgurSettings>());

            services.AddSingleton(configuration.GetSection("PayPalSettings").Get<PayPalSettings>());
        }
    }
}

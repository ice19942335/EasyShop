using EasyShop.Interfaces.Email;
using EasyShop.Interfaces.Services.CP;
using EasyShop.Services.CP.Account;
using EasyShop.Services.CP.FileImage;
using EasyShop.Services.CP.UserProfile;
using EasyShop.Services.Email;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyShop.CP.UI.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //Transient
            services.AddTransient<ISendGridEmailSender, SendGridEmailSender>();
            services.AddTransient<IUserProfileServiceSql, UserProfileServiceSql>();
            services.AddTransient<IFileImageService, FileImageService>();

            services.AddTransient<ISmtpEmailSender, SmtpEmailSender>();

            //Scooped
            services.AddScoped<IAccountService, AccountService>();

            //SingleTone
        }
    }
}

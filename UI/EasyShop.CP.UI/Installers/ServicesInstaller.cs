using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Interfaces.Services.CP;
using EasyShop.Services.Auth.Email;
using EasyShop.Services.CP.FileImage;
using EasyShop.Services.CP.UserProfile;
using EasyShop.Services.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyShop.CP.UI.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //Transient
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IUserProfileServiceSql, UserProfileServiceSql>();
            services.AddTransient<IFileImageService, FileImageService>();

            //Scooped
            services.AddScoped<EasyShopContextInitializer>();

            //SingleTone
        }
    }
}

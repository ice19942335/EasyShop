using EasyShop.Domain.Entries.Tariff;
using EasyShop.Interfaces.Email;
using EasyShop.Interfaces.Services.CP;
using EasyShop.Interfaces.Services.CP.Account;
using EasyShop.Interfaces.Services.CP.FileImage;
using EasyShop.Interfaces.Services.CP.Rust.Data;
using EasyShop.Interfaces.Services.CP.Rust.Server;
using EasyShop.Interfaces.Services.CP.Rust.Shop;
using EasyShop.Interfaces.Services.CP.Tariff;
using EasyShop.Interfaces.Services.CP.UserProfile;
using EasyShop.Services.CP.Account;
using EasyShop.Services.CP.FileImage;
using EasyShop.Services.CP.Rust.Data;
using EasyShop.Services.CP.Rust.Server;
using EasyShop.Services.CP.Rust.Shop;
using EasyShop.Services.CP.Tariff;
using EasyShop.Services.CP.UserProfile;
using EasyShop.Services.Data.FirstRunInitialization.RustShopDataInitialization;
using EasyShop.Services.Email;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyShop.CP.UI.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //Transient ------------------------------------------------------------------------------
            services.AddTransient<IUserProfileServiceSql, UserProfileServiceSql>();

            services.AddTransient<IFileImageService, FileImageService>();

            services.AddTransient<ISendGridEmailSender, SendGridEmailSender>();
            services.AddTransient<ISmtpEmailSender, SmtpEmailSender>();

            services.AddTransient<ITariffService, TariffService>();
            services.AddTransient<ITariffOptionDescriptionService, TariffOptionDescriptionService>();
            services.AddTransient<ITariffOptionsService, TariffOptionsService>();

            services.AddTransient<IShopManager, ShopManager>();
            services.AddTransient<IRustShopService, RustShopService>();

            services.AddTransient<IRustDefaultCategoriesWithItemsService, RustDefaultCategoriesWithItemsService>();

            services.AddTransient<IRustServerService, RustServerService>();

            //Scooped ---------------------------------------------------------------------------------
            services.AddScoped<IAccountService, AccountService>();

            //SingleTone ------------------------------------------------------------------------------

        }
    }
}

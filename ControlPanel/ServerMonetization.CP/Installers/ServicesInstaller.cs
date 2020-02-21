using EasyShop.Interfaces.Email;
using EasyShop.Interfaces.Services.CP.Account;
using EasyShop.Interfaces.Services.CP.Admin.BugReport;
using EasyShop.Interfaces.Services.CP.Admin.Tariff;
using EasyShop.Interfaces.Services.CP.ContactUs;
using EasyShop.Interfaces.Services.CP.DevBlog;
using EasyShop.Interfaces.Services.CP.FileImage;
using EasyShop.Interfaces.Services.CP.Notification;
using EasyShop.Interfaces.Services.CP.Rust.Dashboard;
using EasyShop.Interfaces.Services.CP.Rust.Data;
using EasyShop.Interfaces.Services.CP.Rust.Server;
using EasyShop.Interfaces.Services.CP.Rust.Shop;
using EasyShop.Interfaces.Services.CP.Shop;
using EasyShop.Interfaces.Services.CP.UserProfile;
using EasyShop.Interfaces.Services.Imgur;
using EasyShop.Interfaces.Services.MultiTenancy;
using EasyShop.Interfaces.Services.Payments.Payout.PayPal.Authentication;
using EasyShop.Interfaces.Services.Rust;
using EasyShop.Services.CP.Account;
using EasyShop.Services.CP.Admin.BugReport;
using EasyShop.Services.CP.Admin.Tariff;
using EasyShop.Services.CP.ContactUs;
using EasyShop.Services.CP.DevBlog;
using EasyShop.Services.CP.FileImage;
using EasyShop.Services.CP.Notification;
using EasyShop.Services.CP.Rust.Dashboard;
using EasyShop.Services.CP.Rust.Data;
using EasyShop.Services.CP.Rust.Server;
using EasyShop.Services.CP.Rust.Shop;
using EasyShop.Services.CP.Shop;
using EasyShop.Services.CP.UserProfile;
using EasyShop.Services.Data.FirstRunInitialization.Rust.RustTestStatsData;
using EasyShop.Services.Email;
using EasyShop.Services.Imgur;
using EasyShop.Services.MultiTenancy;
using EasyShop.Services.Payments.Payout.PayPal.Authentication;
using EasyShop.Services.Rust;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ServerMonetization.CP.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //Transient ------------------------------------------------------------------------------

            //Profile services
            services.AddTransient<IUserProfileService, UserProfileService>();

            //Files services
            services.AddTransient<IFileImageService, FileImageService>();

            //Email services
            services.AddTransient<ISendGridEmailSender, SendGridEmailSender>();
            services.AddTransient<ISmtpEmailSender, SmtpEmailSender>();

            //Tariffs services
            services.AddTransient<ITariffService, TariffService>();
            services.AddTransient<ITariffOptionDescriptionService, TariffOptionDescriptionService>();
            services.AddTransient<ITariffOptionsService, TariffOptionsService>();

            //Shop services
            services.AddTransient<IShopService, ShopService>();

            //Rust services
            services.AddTransient<IRustShopService, RustShopService>();
            services.AddTransient<IRustDefaultCategoriesWithItemsService, RustDefaultCategoriesWithItemsService>();
            services.AddTransient<IRustServerService, RustServerService>();
            services.AddTransient<IRustTestStatsData, RustTestStatsData>();
            services.AddTransient<IRustShopStatsService, RustShopStatsService>();

            //DashBoard services
            services.AddTransient<IDashBoardStatsService, DashBoardStatsService>();

            //DevBlog services
            services.AddTransient<IDevBlogService, DevBlogService>();

            //AdminBugReportsService
            services.AddTransient<IAdminBugReportsService, AdminBugReportsService>();

            //Notification services
            services.AddTransient<INotificationService, NotificationService>();

            //TenantStore
            services.AddTransient<IMultiTenancyStoreService, MultiTenancyStoreService>();

            //RustShopSalesService
            services.AddTransient<IRustShopSalesService, RustShopSalesService>();


            //Scooped ---------------------------------------------------------------------------------

            //Account services
            services.AddScoped<IAccountService, AccountService>();

            //Support services
            services.AddScoped<IBugReportService, BugReportService>();

            //ImgUr services
            services.AddScoped<IImgUrService, ImgUrService>();

            //PayPal services
            services.AddScoped<IPayPalAuthenticationService, PayPalAuthenticationService>();


            //SingleTone ------------------------------------------------------------------------------

        }
    }
}

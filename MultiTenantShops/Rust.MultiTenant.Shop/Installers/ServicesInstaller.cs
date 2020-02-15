using EasyShop.Interfaces.Services.CP.Rust.Data;
using EasyShop.Interfaces.Services.MultiTenancy;
using EasyShop.Interfaces.Services.Payments.RustPaymentServices.PayPal;
using EasyShop.Interfaces.Services.Rust;
using EasyShop.Interfaces.Services.Rust.StandardProductPurchase;
using EasyShop.Interfaces.SqlServices.Rust.Stats;
using EasyShop.Interfaces.SteamUsers;
using EasyShop.Services.CP.Rust.Data;
using EasyShop.Services.MultiTenancy;
using EasyShop.Services.Payments.RustPaymentServices.PayPal;
using EasyShop.Services.Rust;
using EasyShop.Services.Rust.Purchase.StandardItem;
using EasyShop.Services.SqlServices.Rust.Stats;
using EasyShop.Services.SteamUsers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Rust.MultiTenant.Shop.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //Transient------------------------------------------------------------------------------------------------------

            //Tenant store service
            services.AddTransient<IMultiTenancyStoreService, MultiTenancyStoreService>();

            //Steam users services
            services.AddTransient<ISteamUserService, SteamUserService>();

            //Rust
            services.AddTransient<IRustShopService, RustShopService>();
            services.AddTransient<IRustDefaultCategoriesWithItemsService, RustDefaultCategoriesWithItemsService>();

            //PayPal services
            services.AddTransient<IPayPalCreatedPaymentService, PayPalCreatedPaymentService>();
            services.AddTransient<IPayPalExecutedPaymentService, PayPalExecutedPaymentService>();

            //Sql stats services
            services.AddTransient<IRustPurchaseStatsServiceSql, RustPurchaseStatsServiceSql>();

            //Scoped---------------------------------------------------------------------------------------------------------
            services.AddScoped<IRustStorePaymentService, RustStoreStorePaymentService>();

            //Rust store standard items purchase
            services.AddScoped<IRustStoreStandardProductPurchaseService, RustStoreStandardProductPurchaseService>();


            //Single-tone----------------------------------------------------------------------------------------------------
        }
    }
}

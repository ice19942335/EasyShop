using EasyShop.Interfaces.MultiTenancy;
using EasyShop.Interfaces.Payments.RustPaymentServices;
using EasyShop.Interfaces.Services.CP.Rust.Data;
using EasyShop.Interfaces.Services.CP.Rust.Shop;
using EasyShop.Services.CP.Rust.Data;
using EasyShop.Services.CP.Rust.Shop;
using EasyShop.Services.MultiTenancy;
using EasyShop.Services.Payments.RustPaymentServices;
using EasyShop.Services.Rust;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Rust.MultiTenant.Shop.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //Transient------------------------------------------------------------------------------------------------------

            //TenantStore
            services.AddTransient<IMultiTenancyStoreService, MultiTenancyStoreService>();

            //Rust
            services.AddTransient<IRustShopService, RustShopService>();
            services.AddTransient<IRustDefaultCategoriesWithItemsService, RustDefaultCategoriesWithItemsService>();

            //Scoped---------------------------------------------------------------------------------------------------------
            services.AddScoped<IRustPaymentService, RustPaymentService>();

            //Single-tone----------------------------------------------------------------------------------------------------
        }
    }
}

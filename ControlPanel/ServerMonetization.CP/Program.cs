using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Settings;
using EasyShop.Interfaces.Services.CP.Rust.Data;
using EasyShop.Services.Data.FirstRunInitialization.ContactUs;
using EasyShop.Services.Data.FirstRunInitialization.IdentityInitialization;
using EasyShop.Services.Data.FirstRunInitialization.Rust.RustShopDataInitialization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ServerMonetization.CP
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                //EasyShopContext
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<EasyShopContext>();
                await dbContext.Database.MigrateAsync();

                //RustShopMultiTenantStoreContext
                var rustShopMultiTenantStoreContext =
                    serviceScope.ServiceProvider.GetRequiredService<RustShopMultiTenantStoreContext>();
                await rustShopMultiTenantStoreContext.Database.MigrateAsync();

                //Services
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                var rustTestStatsInit = serviceScope.ServiceProvider.GetRequiredService<IRustTestStatsData>();
                var configuration = serviceScope.ServiceProvider.GetRequiredService<IConfiguration>();
                var payPalSettings = serviceScope.ServiceProvider.GetRequiredService<PayPalSettings>();

                //Default Identity initialization
                var basicIdentityInitializer = new IdentityInitializer(dbContext, roleManager, userManager, configuration, payPalSettings);
                await basicIdentityInitializer.InitializeIdentity();
                

                //Default Rust data initialization
                var rustDataInit = new RustDefaultDataInitialization(dbContext);
                await rustDataInit.Initialize();


                //RustTestStats initialization
                await rustTestStatsInit.InitializeDefaultStatsData();

                var contactUsDataInit = new ContactUsDataInitializer(dbContext);
                await contactUsDataInit.Initialize();

                await dbContext.SaveChangesAsync();
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging((host, log) =>
                {
                    //Just an example, for knowledge
                    //log.AddFilter<ConsoleLoggerProvider>("System", LogLevel.Error);
                });
    }
}

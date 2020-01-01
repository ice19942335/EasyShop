using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Interfaces.Services.CP.Rust.Data;
using EasyShop.Services.Data.FirstRunInitialization.IdentityInitialization;
using EasyShop.Services.Data.FirstRunInitialization.Rust.RustShopDataInitialization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EasyShop.CP.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<EasyShopContext>();

                await dbContext.Database.MigrateAsync();

                //Services
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                var rustTestStatsData = serviceScope.ServiceProvider.GetRequiredService<IRustTestStatsData>();
                
                //Default Identity initialization
                var basicIdentityInitializer = new IdentityInitializer(dbContext, roleManager, userManager);
                await basicIdentityInitializer.InitializeIdentity();
                

                //Default Rust data initialization
                var rustDefaultDataInitialization = new RustDefaultDataInitialization(dbContext);
                await rustDefaultDataInitialization.Initialize();
                //RustTestStats initialization
                await rustTestStatsData.InitializeDefaultStatsData();

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

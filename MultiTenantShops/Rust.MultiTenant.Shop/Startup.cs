using System;
using EasyShop.DAL.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Finbuckle.MultiTenant;
using Microsoft.Extensions.DependencyInjection;
using Rust.MultiTenant.Shop.ConfigureServicesInstallers;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Rust.MultiTenant.Shop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.InstallServicesInAssembly(Configuration);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMultiTenant();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{__tenant__=}/{controller=Home}/{action=Index}");
            });

            // Seed the database the multitenant store will need.
            SetupStore(app.ApplicationServices);
        }

        private void SetupStore(IServiceProvider sp)
        {
            var scopeServices = sp.CreateScope().ServiceProvider;
            var store = scopeServices.GetRequiredService<IMultiTenantStore>();

            store.TryAddAsync(new TenantInfo("tenant-finbuckle-d043favoiaw", "finbuckle", "Finbuckle", "finbuckle_conn_string", null)).Wait();
            store.TryAddAsync(new TenantInfo("tenant-initech-341ojadsfa", "initech", "Initech LLC", "initech_conn_string", null)).Wait();
        }
    }
}

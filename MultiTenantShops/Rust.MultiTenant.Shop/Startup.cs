using System;
using EasyShop.DAL.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rust.MultiTenant.Shop.Controllers;
using Rust.MultiTenant.Shop.Extensions;
using Rust.MultiTenant.Shop.Installers;
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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error/ErrorHandler/500");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMultiTenant();

            app.UseRustShopExistResolver();
            app.UseSteamUserResolver();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Multi-Tenant pattern", "{__tenant__=}/{controller=Store}/{action=Store}");
            });
        }
    }
}

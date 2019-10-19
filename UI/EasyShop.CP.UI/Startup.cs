using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Clients.Users;
using EasyShop.Domain.Entities.Identity;
using EasyShop.Interfaces.Services;
using EasyShop.Services.UserServices.UserData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EasyShop.CP.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddRazorPages();

            services.AddIdentity<ApplicationUser, IdentityRole>(options => { /*Cookies configuration can be hire*/ })
                .AddDefaultTokenProviders();

            services.AddTransient<IUserStore<ApplicationUser>, UserClient>();
            services.AddTransient<IUserClaimStore<ApplicationUser>, UserClient>();
            services.AddTransient<IUserPasswordStore<ApplicationUser>, UserClient>();
            services.AddTransient<IUserTwoFactorStore<ApplicationUser>, UserClient>();
            services.AddTransient<IUserEmailStore<ApplicationUser>, UserClient>();
            services.AddTransient<IUserPhoneNumberStore<ApplicationUser>, UserClient>();
            services.AddTransient<IUserLoginStore<ApplicationUser>, UserClient>();
            services.AddTransient<IUserLockoutStore<ApplicationUser>, UserClient>();
            services.AddTransient<IRoleStore<IdentityRole>, RoleClient>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;

                options.Lockout.MaxFailedAccessAttempts = 30;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(7); //..........................    New in Core 3
                options.Cookie.MaxAge = TimeSpan.FromDays(7);

                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";

                options.SlidingExpiration = true; //.......................................    Change Session ID if being authorized
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseDefaultFiles();

            app.UseRouting();

            app.UseAuthentication(); //Should be after "UseRouting" middleware
            app.UseAuthorization();  //Should be after "UseRouting" middleware

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}

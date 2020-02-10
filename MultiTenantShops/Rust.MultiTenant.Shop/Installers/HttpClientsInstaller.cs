using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace Rust.MultiTenant.Shop.Installers
{
    public class HttpClientsInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            ////IHttpFactory sample
            //services.AddHttpClient("PayPal", client =>
            //{
            //    client.BaseAddress = new Uri("https://api.sandbox.paypal.com");
            //    client.Timeout = TimeSpan.FromSeconds(30);
            //})
            //    .AddTransientHttpErrorPolicy(x => x.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(300)));
        }
    }
}

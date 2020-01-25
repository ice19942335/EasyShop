using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using MultiTenancyStrategy.Accessors.Services;
using MultiTenancyStrategy.Models;

namespace MultiTenancyStrategy.Middleware
{
    public class TenantMiddleware<T> where T : Tenant
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Items.ContainsKey("HttpContextTenantKey"))
            {
                var tenantService = context.RequestServices.GetService(typeof(TenantAccessService<T>)) as TenantAccessService<T>;
                context.Items.Add("HttpContextTenantKey", await tenantService.GetTenantAsync());
            }

            //Continue processing
            if (_next != null)
                await _next(context);
        }
    }
}

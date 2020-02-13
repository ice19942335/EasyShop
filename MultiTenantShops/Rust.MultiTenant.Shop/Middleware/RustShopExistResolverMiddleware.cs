using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Http;

namespace Rust.MultiTenant.Shop.Middleware
{
    public class RustShopExistResolverMiddleware
    {
        private readonly RequestDelegate _next;

        public RustShopExistResolverMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {

            var tenant = httpContext.GetMultiTenantContext();

            string path = httpContext.Request.Path;

            if (path.Contains("/Error/ShopNotFound"))
                await _next(httpContext);

            if (tenant.TenantInfo is null)
            {
                var redirectLink = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/Error/ShopNotFound";
                httpContext.Response.Redirect(redirectLink);
            }
            else
            {
                await _next(httpContext);
            }
        }
    }
}

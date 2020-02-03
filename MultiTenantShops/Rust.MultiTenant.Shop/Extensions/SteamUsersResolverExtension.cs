using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Rust.MultiTenant.Shop.Middleware;

namespace Rust.MultiTenant.Shop.Extensions
{
    public static class SteamUsersResolverExtension
    {
        /// <summary>
        /// Adding SteamUserResolver middleware to a app request pipeline
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSteamUserResolver(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SteamUsersResolverMiddleware>();
        }
    }
}

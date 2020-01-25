﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using MultiTenancyStrategy.Middleware;
using MultiTenancyStrategy.Models;

namespace MultiTenancyStrategy.Extensions
{
    /// <summary>
    /// Nice method to register our middleware
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Use the Tenant Middleware to process the request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseMultiTenancy<T>(this IApplicationBuilder builder) where T : Tenant
            => builder.UseMiddleware<TenantMiddleware<T>>();

        /// <summary>
        /// Use the Tenant Middleware to process the request
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseMultiTenancy(this IApplicationBuilder builder)
            => builder.UseMiddleware<TenantMiddleware<Tenant>>();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using MultiTenancyStrategy.Extensions;
using MultiTenancyStrategy.Interfaces;
using MultiTenancyStrategy.Models;

namespace MultiTenancyStrategy.Accessors
{
    public class TenantAccessor<T> : ITenantAccessor<T> where T : Tenant
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public T Tenant => _httpContextAccessor.HttpContext.GetTenant<T>();
    }
}

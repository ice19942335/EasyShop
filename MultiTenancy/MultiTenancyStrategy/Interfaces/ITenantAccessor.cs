using System;
using System.Collections.Generic;
using System.Text;
using MultiTenancyStrategy.Models;

namespace MultiTenancyStrategy.Interfaces
{
    public interface ITenantAccessor<T> where T : Tenant
    {
        T Tenant { get; }
    }
}

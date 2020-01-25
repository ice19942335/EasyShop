using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyShop.Interfaces.MultiTenancy
{
    public interface ITenantResolutionStrategy
    {
        Task<string> GetTenantIdentifierAsync();
    }
}

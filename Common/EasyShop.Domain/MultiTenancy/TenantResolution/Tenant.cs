using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShop.Domain.MultiTenancy.TenantResolution
{
    /// <summary>
    /// Tenant information
    /// </summary>
    public class Tenant
    {
        /// <summary>
        /// The tenant Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The tenant identifier
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Tenant items
        /// </summary>
        public Dictionary<string, object> Items { get; private set; } = new Dictionary<string, object>();
    }
}

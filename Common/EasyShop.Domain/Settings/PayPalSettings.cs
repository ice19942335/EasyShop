using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShop.Domain.Settings
{
    public class PayPalSettings
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public int Fees { get; set; }
    }
}

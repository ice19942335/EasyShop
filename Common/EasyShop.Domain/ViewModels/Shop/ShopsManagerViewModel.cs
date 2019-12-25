using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShop.Domain.ViewModels.Shop
{
    public class ShopsManagerViewModel
    {
        public IEnumerable<Entries.Shop.Shop> Shops { get; set; }
    }
}

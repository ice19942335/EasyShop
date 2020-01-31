using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShop.Domain.ViewModels.RustStore.Store
{
    public class RustStoreViewModel
    {
        public string ShopName { get; set; }

        public IEnumerable<RustStoreProductViewModel> Products { get; set; }

        public Dictionary<string, string> ProductCategories { get; set; }
    }
}

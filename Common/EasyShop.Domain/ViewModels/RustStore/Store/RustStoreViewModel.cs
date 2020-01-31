using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShop.Domain.ViewModels.RustStore.Store
{
    public class RustStoreViewModel
    {
        public IEnumerable<RustStoreProductViewModel> Products { get; set; }
    }
}

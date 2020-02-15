using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShop.Domain.ViewModels.RustStore.Store.Purchase
{
    public class RustStorePurchaseHistoryViewModel
    {
        public IEnumerable<RustPurchasedProductViewModel> PurchasedProducts { get; set; }   
    }
}

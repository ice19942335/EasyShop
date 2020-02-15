using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShop.Domain.ViewModels.RustStore.Store.Purchase
{
    public class RustPurchasedProductViewModel
    {
        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public decimal PaidTotal { get; set; }

        public int AmountOnPurchase { get; set; }

        public int AmountLeft { get; set; }

        public DateTime PurchaseDateTime { get; set; }
    }
}

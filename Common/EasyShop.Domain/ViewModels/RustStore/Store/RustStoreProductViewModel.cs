using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShop.Domain.ViewModels.RustStore.Store
{
    public class RustStoreProductViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int ItemsPerStack { get; set; }

        public decimal PriceAfterDiscount { get; set; }

        public decimal Discount { get; set; }

        public DateTime BlockedTill { get; set; }

        public string ImgUrl { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Type { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EasyShop.Domain.ViewModels.RustStore.Store.Order
{
    public class RustStoreStandardItemOrder
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int Amount { get; set; }

        [Required]
        [StringLength(maximumLength: 38, MinimumLength = 38, ErrorMessage = "Product ID is required")]
        public string ItemId { get; set; }
    }
}

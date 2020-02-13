using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EasyShop.Domain.ViewModels.RustStore.Store.Order
{
    public class RustStoreStandardItemOrder
    {
        [Required]
        public int Amount { get; set; }

        [Required]
        public string ProductId { get; set; }
    }
}

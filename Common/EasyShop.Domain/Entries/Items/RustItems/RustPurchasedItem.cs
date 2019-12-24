using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Entries.Identity;

namespace EasyShop.Domain.Entries.Items.RustItems
{
    [Table("RustPurchasedItems")]
    public class RustPurchasedItem
    {
        public Guid Id { get; set; }

        public AppUser AppUser { get; set; }

        public RustItem RustItem { get; set; }

        public int Amount { get; set; }

        public int RustUserItemAmount { get; set; }

        public DateTime PurchaseDateTime { get; set; }
    }
}
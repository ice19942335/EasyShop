using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Entries.Identity;

namespace EasyShop.Domain.Entries.Items.RustItems
{
    [Table("RustPurchasedItems")]
    public class RustPurchasedItem
    {
        public Guid RustUserId { get; set; }
        public RustUser RustUser { get; set; }


        public Guid RustUserItemId { get; set; }
        public RustUserItem RustUserItem { get; set; }

        public int Amount { get; set; }

        public DateTime PurchaseDateTime { get; set; }
    }
}
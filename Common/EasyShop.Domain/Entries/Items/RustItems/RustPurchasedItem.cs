using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using EasyShop.Domain.Entries.Identity;

namespace EasyShop.Domain.Entries.Items.RustItems
{
    [Table("RustPurchasedItems")]
    public class RustPurchasedItem
    {
        public Guid Id { get; set; }

        public RustUser RustUser { get; set; }

        public RustItem RustItem { get; set; }

        [Required]
        public bool HasBeenUsed { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public int RustUserItemAmount { get; set; }

        [Required]
        public DateTime PurchaseDateTime { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Users;

namespace EasyShop.Domain.Entries.Rust
{
    [Table("RustPurchasedItems")]
    public class RustPurchasedItem
    {
        public Guid Id { get; set; }

        public SteamUser SteamUser { get; set; }

        public RustItem RustItem { get; set; }

        [Required]
        public DateTime PurchaseDateTime { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public Decimal TotalPaid { get; set; }

        [Required]
        public int ItemsPerStack { get; set; }

        public int AmountLeft { get; set; }

        public int AmountOnPurchase { get; set; }
    }
}
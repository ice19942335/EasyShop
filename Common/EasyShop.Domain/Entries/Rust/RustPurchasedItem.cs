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

        public SteamUser RustUser { get; set; }

        public RustItem RustItem { get; set; }

        [Required]
        public bool HasBeenUsed { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public DateTime PurchaseDateTime { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public Decimal TotalPaid { get; set; }
    }
}
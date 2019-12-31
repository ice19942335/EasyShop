using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using EasyShop.Domain.Entries.Identity;

namespace EasyShop.Domain.Entries.Rust
{
    [Table("RustPurchaseStats")]
    public class RustPurchaseStats
    {
        [Key]
        public Guid Id { get; set; }

        [Required] public AppUser AppUser { get; set; }

        [Required] public RustPurchasedItem RustPurchasedItem { get; set; }
        
        [Required] public Shop.Shop Shop { get; set; }
    }
}

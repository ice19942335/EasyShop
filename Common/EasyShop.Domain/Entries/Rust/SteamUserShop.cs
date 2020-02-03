using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Entries.Users;

namespace EasyShop.Domain.Entries.Rust
{
    [Table("SteamUserShops")]
    public class SteamUserShop
    {
        [Key]
        public Guid ShopId { get; set; }
        public Shop.Shop Shop { get; set; }

        [Key]
        public Guid SteamUserId { get; set; }
        public SteamUser SteamUser { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        public Decimal Balance { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public Decimal TotalSpent { get; set; }
    }
}

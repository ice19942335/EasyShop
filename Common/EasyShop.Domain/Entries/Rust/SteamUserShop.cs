using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Entries.Base;
using EasyShop.Domain.Entries.Users;

namespace EasyShop.Domain.Entries.Rust
{
    [Table("SteamUserShops")]
    public class SteamUserShop : BaseEntity
    {
        public Shop.Shop Shop { get; set; }

        public SteamUser SteamUser { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public Decimal StartBalance { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public Decimal Balance { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public Decimal TotalSpent { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public Decimal TotalToppedUp { get; set; }
    }
}

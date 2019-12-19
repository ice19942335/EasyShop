using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Entries.Base;
using EasyShop.Domain.Entries.Identity;

namespace EasyShop.Domain.Entries.Shop
{
    [Table("Shops")]
    public class Shop
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string ShopName { get; set; }

        [Required]
        public GameType GameType { get; set; }

        [Required]
        public string ShopTitle { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal StartBalance { get; set; }

        [Required]
        public Guid Secret { get; set; }

        public ICollection<UserShop> UserShops { get; set; }

        public ICollection<ServerShop> ServerShops { get; set; }
    }
}
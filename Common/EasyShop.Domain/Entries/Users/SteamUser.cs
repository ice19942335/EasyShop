using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using EasyShop.Domain.Entries.Rust;

namespace EasyShop.Domain.Entries.Users
{
    [Table("SteamUsers")]
    public class SteamUser
    {
        [Key] 
        public Guid Id { get; set; }

        public string Uid { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public Decimal TotalSpent { get; set; }

        public ICollection<SteamUserShop> SteamUserShops { get; set; }
    }
}

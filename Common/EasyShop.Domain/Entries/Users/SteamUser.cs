using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EasyShop.Domain.Entries.Users
{
    [Table("SteamUsers")]
    public class SteamUser
    {
        public Guid Id { get; set; }

        [Required]
        public string Uid { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Balance { get; set; }

        public ICollection<SteamUserShop> SteamUserShops { get; set; }
    }
}

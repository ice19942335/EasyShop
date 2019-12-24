using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Entries.Identity;

namespace EasyShop.Domain.Entries.Items.RustItems
{
    [Table("RustUserItems")]
    public class RustUserItem
    {
        #region PK
        public Guid Id { get; set; }
        #endregion

        #region FK
        public RustCategory RustCategory { get; set; }
        public RustItem RustItem { get; set; }
        public Shop.Shop Shop { get; set; }
        public AppUser AppUser { get; set; }
        #endregion

        #region Entrie columns
        [Required]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        public int Amount { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Discount { get; set; }

        public DateTime BlockedTill { get; set; }
        #endregion
    }
}
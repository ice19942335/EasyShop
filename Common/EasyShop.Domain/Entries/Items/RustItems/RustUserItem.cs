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
        [Required]
        public RustCategory RustCategory { get; set; }
        [Required]
        public RustItem RustItem { get; set; }
        [Required]
        public Shop.Shop Shop { get; set; }
        [Required]
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
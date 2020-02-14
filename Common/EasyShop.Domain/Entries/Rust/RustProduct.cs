using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Entries.Identity;

namespace EasyShop.Domain.Entries.Rust
{
    [Table("RustUserItems")]
    public class RustProduct
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
        public int ItemsPerStack { get; set; }

        public string Description { get; set; }

        public int Discount { get; set; }

        public DateTime BlockedTill { get; set; }

        [Required]
        public bool ShowInShop { get; set; }

        [Required]
        public int Index { get; set; }

        #endregion
    }
}
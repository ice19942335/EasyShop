using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyShop.Domain.Entries.Items.RustItems
{
    [Table("RustItems")]
    public class RustItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string RustId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public RustItemType RustItemType { get; set; }

        [Required]
        public string ImgUrl { get; set; }

        public ICollection<RustShopItem> RustShopItems { get; set; }

        public ICollection<RustItemCategory> RustItemCategories { get; set; }

        public ICollection<RustItemsPurchased> RustItemsPurchased { get; set; }
    }
}
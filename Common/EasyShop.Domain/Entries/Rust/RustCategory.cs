using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Entries.Identity;

namespace EasyShop.Domain.Entries.Rust
{
    [Table("RustCategories")]
    public class RustCategory
    {
        [Key]
        public Guid Id { get; set; }

        public int Index { get; set; }

        [Required]
        public string Name { get; set; }

        public AppUser AppUser { get; set; }

        public Shop.Shop Shop { get; set; }
    }
}
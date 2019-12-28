using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyShop.Domain.Entries.Rust
{
    [Table("RustItems")]
    public class RustItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string RustItemInGameId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public RustItemType RustItemType { get; set; }

        [Required]
        public string ImgUrl { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyShop.Domain.Entries.Rust
{
    [Table("RustServerMaps")]
    public class RustServerMap
    {
        [Key] public Guid Id { get; set; }

        [Required] public string Type { get; set; }
    }
}
﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyShop.Domain.Entries.Rust
{
    [Table("RustItemTypes")]
    public class RustItemType
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string TypeName { get; set; }
    }
}
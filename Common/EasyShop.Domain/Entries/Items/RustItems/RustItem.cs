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
        public string RustItemInGameId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public RustItemType RustItemType { get; set; }

        [Required]
        public string ImgUrl { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Entries.Identity;

namespace EasyShop.Domain.Entries.Items.RustItems
{
    [Table("RustCategories")]
    public class RustCategory
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public AppUser AppUser { get; set; }
    }
}
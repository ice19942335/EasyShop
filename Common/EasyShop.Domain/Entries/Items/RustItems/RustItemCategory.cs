using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyShop.Domain.Entries.Items.RustItems
{
    [Table("RustItemCategories")]
    public class RustItemCategory
    {
        public Guid RustCategoryId { get; set; }
        public RustCategory RustCategory { get; set; }


        public Guid RustItemId { get; set; }
        public RustItem RustItem { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EasyShop.Domain.Entries.Items.RustItems
{
    [Table("RustShopItems")]
    public class RustShopItem
    {
        public Guid ShopId { get; set; }
        public Shop.Shop Shop { get; set; }


        public Guid RustItemId { get; set; }
        public RustItem RustItem { get; set; }
    }
}

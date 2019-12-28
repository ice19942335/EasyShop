using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyShop.Domain.Entries.Servers
{
    [Table("RustServerShops")]
    public class RustServerShop
    {
        public Guid ShopId { get; set; }
        public Shop.Shop Shop { get; set; }


        public Guid ServerId { get; set; }
        public RustServer Server { get; set; }

    }
}

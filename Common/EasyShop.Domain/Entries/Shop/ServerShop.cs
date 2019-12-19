using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyShop.Domain.Entries.Shop
{
    [Table("ServerShops")]
    public class ServerShop
    {
        public Guid ShopId { get; set; }
        public Shop Shop { get; set; }

        public int ServerId { get; set; }
        public Server Server { get; set; }
    }
}
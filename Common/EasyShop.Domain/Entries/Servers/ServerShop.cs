using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyShop.Domain.Entries.Servers
{
    [Table("ServerShops")]
    public class ServerShop
    {
        public Guid ShopId { get; set; }
        public Shop.Shop Shop { get; set; }

        public int ServerId { get; set; }
        public Server Server { get; set; }
    }
}
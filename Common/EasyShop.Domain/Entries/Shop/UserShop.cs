using System;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Entries.Identity;

namespace EasyShop.Domain.Entries.Shop
{
    [Table("UserShops")]
    public class UserShop
    {
        public Guid ShopId { get; set; }
        public Shop Shop { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}

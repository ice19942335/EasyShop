using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text;
using EasyShop.Domain.Entries.Identity;

namespace EasyShop.Domain.Entries.Shop
{
    [Table("UserShops")]
    public class UserShop
    {
        public int ShopId { get; set; }
        public Shop Shop { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}

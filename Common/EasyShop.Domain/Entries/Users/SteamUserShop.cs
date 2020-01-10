using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using EasyShop.Domain.Entries.Identity;

namespace EasyShop.Domain.Entries.Users
{
    [Table("SteamUserShops")]
    public class SteamUserShop
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }


        public Guid StemUserId { get; set; }
        public SteamUser SteamUser { get; set; }
    }
}

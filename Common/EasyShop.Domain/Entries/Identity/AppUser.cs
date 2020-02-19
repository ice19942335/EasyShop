using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Entries.DevBlog;
using EasyShop.Domain.Entries.Notification;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Domain.Entries.Tariff;
using EasyShop.Domain.Entries.Users;
using Microsoft.AspNetCore.Identity;

namespace EasyShop.Domain.Entries.Identity
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        public string ProfileImage { get; set; }

        public int ShopsAllowed { get; set; }

        public int TransactionPercent { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Balance { get; set; }

        public bool UsingTariff { get; set; }

        public Dictionary<Tariff.Tariff, DateTime> PurchasedTariffs { get; set; }

        public ICollection<UserTariff> UserTariffs { get; set; }

        public ICollection<UserShop> UserShops { get; set; }

        public ICollection<DevBlogPostsLike> DevBlogPostsLikes { get; set; }

        public ICollection<UserNotification> UserNotifications { get; set; }
    }
}

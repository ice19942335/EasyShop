using System;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Entries.Identity;

namespace EasyShop.Domain.Entries.Notification
{
    [Table("UserNotifications")]
    public class UserNotification
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }


        public Guid NotificationId { get; set; }
        public Notification Notification { get; set; }
    }
}
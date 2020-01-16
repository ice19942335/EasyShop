using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EasyShop.Domain.Entries.Notification
{
    [Table("Notifications")]
    public class Notification
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public string LinkTitle { get; set; }

        public string Link { get; set; }

        public ICollection<UserNotification> UserNotifications { get; set; }
    }
}

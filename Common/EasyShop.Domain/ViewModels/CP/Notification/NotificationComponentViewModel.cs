using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShop.Domain.ViewModels.CP.Notification
{
    public class NotificationComponentViewModel
    {
        public IEnumerable<NotificationViewModel> NotificationViewModels { get; set; }

        public int NewNotifications { get; set; }
    }
}

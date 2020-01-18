using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShop.Domain.ViewModels.CP.Notification
{
    public class NotificationsListViewModel
    {
        public IEnumerable<NotificationViewModel> NotificationViewModels { get; set; }

        public string Url { get; set; }
    }
}

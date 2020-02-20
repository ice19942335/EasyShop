using System.Collections.Generic;

namespace EasyShop.Domain.ViewModels.ControlPanel.Notification
{
    public class NotificationComponentViewModel
    {
        public IEnumerable<NotificationViewModel> NotificationViewModels { get; set; }

        public int NewNotifications { get; set; }
    }
}

using System.Collections.Generic;

namespace EasyShop.Domain.ViewModels.ControlPanel.Notification
{
    public class NotificationsListViewModel
    {
        public IEnumerable<NotificationViewModel> NotificationViewModels { get; set; }

        public string Url { get; set; }

        public PageViewModel.PageViewModel PageViewModel { get; set; }
    }
}

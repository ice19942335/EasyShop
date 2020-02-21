using System;

namespace EasyShop.Domain.ViewModels.ControlPanel.Notification
{
    public class NotificationViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public string LinkTitle { get; set; }

        public string Link { get; set; }

        public bool Reviewed { get; set; }

        public DateTime DateTimeCreated { get; set; }

        public bool Updated { get; set; }
    }
}

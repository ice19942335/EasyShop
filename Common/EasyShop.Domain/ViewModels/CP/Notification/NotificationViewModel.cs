using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShop.Domain.ViewModels.CP.Notification
{
    public class NotificationViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public string LinkTitle { get; set; }

        public string Link { get; set; }

        public bool Reviewed { get; set; }
    }
}

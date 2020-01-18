using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.ViewModels.CP.Admin.BugReport;
using EasyShop.Domain.ViewModels.CP.Notification;

namespace EasyShop.Services.Mappers.ViewModels.Notification
{
    public static class NotificationViewModelMapper
    {
        public static NotificationViewModel CreateNotificationViewModel(this Domain.Entries.Notification.Notification notification, bool reviewed)
        {
            var model = notification.CopyToNotificationViewModel(reviewed);
            return model;
        }

        private static NotificationViewModel CopyToNotificationViewModel(this Domain.Entries.Notification.Notification notification, bool reviewed)
        {
            var model = new NotificationViewModel
            {
                Id = notification.Id.ToString(),
                Title = notification.Title,
                Message = notification.Message,
                LinkTitle = notification.LinkTitle,
                Link = notification.Link,
                Reviewed = reviewed,
                DateTimeCreated = notification.DateTimeCreated
            };

            return model;
        }
    }
}

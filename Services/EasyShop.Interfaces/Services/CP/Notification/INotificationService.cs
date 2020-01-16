using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.ViewModels.CP.Notification;

namespace EasyShop.Interfaces.Services.CP.Notification
{
    public interface INotificationService
    {
        Task<bool> Update(NotificationViewModel model);

        IEnumerable<Domain.Entries.Notification.Notification> GetAllNotifications();

        Domain.Entries.Notification.Notification GetNotificationById(Guid notificationId);

        bool IsItViewedNotification(AppUser user, Domain.Entries.Notification.Notification notification);
    }
}

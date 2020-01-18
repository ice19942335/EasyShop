using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Enums.CP.Notification;
using EasyShop.Domain.ViewModels.CP.Notification;

namespace EasyShop.Interfaces.Services.CP.Notification
{
    public interface INotificationService
    {
        Task<NotificationResultEnum> Update(NotificationViewModel model);

        Task<IEnumerable<Domain.Entries.Notification.Notification>> GetAllNotifications();

        Task<IEnumerable<Domain.Entries.Notification.Notification>> GetLastTenNotifications();

        Domain.Entries.Notification.Notification GetNotificationById(Guid notificationId);

        Task<bool> IsNotificationReviewed(Domain.Entries.Notification.Notification notification);
        Task<bool> MarkAsReadById(Guid notificationId);
    }
}

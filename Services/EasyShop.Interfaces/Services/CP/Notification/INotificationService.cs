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
        Task<NotificationResultEnum> UpdateAsync(NotificationViewModel model);

        Task<IEnumerable<Domain.Entries.Notification.Notification>> GetAllNotificationsAsync();

        Task<IEnumerable<Domain.Entries.Notification.Notification>> GetLastTenNotificationsAsync();

        Domain.Entries.Notification.Notification GetNotificationById(Guid notificationId);

        Task<bool> IsNotificationReviewed(Domain.Entries.Notification.Notification notification);

        Task<bool> MarkAsReadByIdAsync(Guid notificationId);

        Task MarkAllAsReadAsync();

        Task<bool> DeleteNotificationAsync(Guid notificationId);

        Task<int> GetNewNotificationsCount();
    }
}

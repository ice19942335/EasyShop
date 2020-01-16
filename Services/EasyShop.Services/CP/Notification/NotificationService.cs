using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.ViewModels.CP.Notification;
using EasyShop.Interfaces.Services.CP.Notification;

namespace EasyShop.Services.CP.Notification
{
    public class NotificationService : INotificationService
    {
        public Task<bool> Update(NotificationViewModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Entries.Notification.Notification> GetAllNotifications()
        {
            throw new NotImplementedException();
        }

        public Domain.Entries.Notification.Notification GetNotificationById(Guid notificationId)
        {
            throw new NotImplementedException();
        }

        public bool IsItViewedNotification(AppUser user, Domain.Entries.Notification.Notification notification)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.CP.Notification;
using EasyShop.Interfaces.Services.CP.Notification;
using EasyShop.Services.Mappers.ViewModels.Notification;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.CP.UI.Components.ControlPanel.NavBar
{
    public class NavBarNotificationViewComponent : ViewComponent
    {
        private readonly INotificationService _notificationService;

        public NavBarNotificationViewComponent(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IViewComponentResult Invoke()
        {
            var allNotifications = _notificationService.GetLastTenNotifications().Result;

            var notificationsViewModelsList = allNotifications.Select(x =>
            {
                var isNotificationReviewed = _notificationService.IsNotificationReviewed(x).Result;
                var notificationModel =  x.CreateNotificationViewModel(isNotificationReviewed);

                return notificationModel;
            });

            return View("NotificationsComponent", notificationsViewModelsList.AsEnumerable());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.Enums.CP.Notification;
using EasyShop.Domain.ViewModels.CP.Notification;
using EasyShop.Interfaces.Services.CP.Notification;
using EasyShop.Services.Mappers.ViewModels.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.CP.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [Authorize(Roles = "Admin,User")]
        public IActionResult NotificationList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditNotification(string notificationId, bool updated = false)
        {
            if (notificationId is null)
                return View(new NotificationViewModel());

            var notification = _notificationService.GetNotificationById(Guid.Parse(notificationId));

            var isNotificationReviewed = await _notificationService.IsNotificationReviewed(notification);

            var model = notification.CreateNotificationViewModel(isNotificationReviewed);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditNotification([FromForm] NotificationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToList();
                errors.ForEach(x => ModelState.AddModelError("", x));
                return View(model);
            }

            var result = await _notificationService.Update(model);

            if (result == NotificationResultEnum.Updated)
                return RedirectToAction("EditNotification", "Notification", new { updated = true });

            if (result == NotificationResultEnum.Created)
                return RedirectToAction("NotificationList", "Notification");

            return RedirectToAction("SomethingWentWrong", "ControlPanel");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Enums.CP.Notification;
using EasyShop.Domain.ViewModels.CP.Notification;
using EasyShop.Interfaces.Services.CP.Notification;
using EasyShop.Services.Mappers.ViewModels.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyShop.CP.UI.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IActionResult NotificationList(int page = 1)
        {
            var allNotifications = _notificationService.GetAllNotificationsAsync().Result;

            IEnumerable<NotificationViewModel> notificationsViewModels = allNotifications.Select(x =>
            {
                var isNotificationReviewed = _notificationService.IsNotificationReviewed(x).Result;
                var notificationModel = x.CreateNotificationViewModel(isNotificationReviewed);

                return notificationModel;
            });

            int pageSize = 10;
            var notificationViewModelsList = notificationsViewModels.ToList();
            var allNotificationCount = notificationViewModelsList.Count;
            var notificationsInPage = notificationViewModelsList.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            NotificationPageViewModel notificationPageModel = new NotificationPageViewModel(allNotificationCount, page, pageSize);

            var model = new NotificationsListViewModel
            {
                NotificationViewModels = notificationsInPage,
                Url = Url.Action("MarkAsRead", "Notification", new {}, HttpContext.Request.Scheme),
                NotificationPageViewModel = notificationPageModel
            };

            return View(model);
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditNotification([FromForm] NotificationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToList();
                errors.ForEach(x => ModelState.AddModelError("", x));
                return View(model);
            }

            var result = await _notificationService.UpdateAsync(model);

            if (result == NotificationResultEnum.Updated)
                return RedirectToAction("EditNotification", "Notification", new { updated = true });

            if (result == NotificationResultEnum.Created)
                return RedirectToAction("NotificationList", "Notification");

            return RedirectToAction("SomethingWentWrong", "ControlPanel");
        }

        public async Task<IActionResult> MarkAsRead(string notificationId)
        {
            var result = await _notificationService.MarkAsReadByIdAsync(Guid.Parse(notificationId));

            if (!result)
                return Problem("Error on marking as read execution", null, 500);

            return NoContent();
        }

        public async Task<IActionResult> MarkAllAsRead()
        {
            await _notificationService.MarkAllAsReadAsync();

            return RedirectToAction("NotificationList", "Notification");
        }

        public async Task<IActionResult> DeleteNotification(string notificationId)
        {
            var result = await _notificationService.DeleteNotificationAsync(Guid.Parse(notificationId));

            if (!result)
                return RedirectToAction("SomethingWentWrong", "ControlPanel");

            return RedirectToAction("NotificationList", "Notification");
        }
    }
}
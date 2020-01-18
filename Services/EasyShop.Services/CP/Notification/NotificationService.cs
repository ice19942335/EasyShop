using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Notification;
using EasyShop.Domain.Enums.CP.Notification;
using EasyShop.Domain.ViewModels.CP.Notification;
using EasyShop.Interfaces.Services.CP.Notification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;

namespace EasyShop.Services.CP.Notification
{
    public class NotificationService : INotificationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly EasyShopContext _context;

        public NotificationService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, EasyShopContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _context = context;
        }

        public async Task<NotificationResultEnum> UpdateAsync(NotificationViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            if (user is null)
                return NotificationResultEnum.Failed;

            if (model.Id is null)
            {
                var newNotification = new Domain.Entries.Notification.Notification();

                newNotification.Id = Guid.NewGuid();
                newNotification.Title = model.Title;
                newNotification.Message = model.Message;
                newNotification.LinkTitle = model.LinkTitle;
                newNotification.Link = model.Link;
                newNotification.DateTimeCreated = DateTime.Now;

                _context.Add(newNotification);
                await _context.SaveChangesAsync();

                return NotificationResultEnum.Created;
            }

            var notification = new Domain.Entries.Notification.Notification();

            notification.Title = model.Title;
            notification.Message = model.Message;
            notification.LinkTitle = model.LinkTitle;
            notification.Link = model.Link;

            _context.Add(notification);
            await _context.SaveChangesAsync();

            return NotificationResultEnum.Updated;
        }

        public async Task<IEnumerable<Domain.Entries.Notification.Notification>> GetLastTenNotificationsAsync()
        {
            var allNotifications = await GetAllNotificationsAsync();
            return allNotifications.Take(10);
        }

        public async Task<IEnumerable<Domain.Entries.Notification.Notification>> GetAllNotificationsAsync()
        {
            var reviewedNotifications = new List<Domain.Entries.Notification.Notification>();
            var notReviewedNotifications = new List<Domain.Entries.Notification.Notification>();
            var result = new List<Domain.Entries.Notification.Notification>();

            foreach (var notification in _context.Notifications)
            {
                if (await IsNotificationReviewed(notification))
                    reviewedNotifications.Add(notification);
                else
                    notReviewedNotifications.Add(notification);
            }

            reviewedNotifications = reviewedNotifications.OrderByDescending(x => x.DateTimeCreated).ToList();
            notReviewedNotifications = notReviewedNotifications.OrderByDescending(x => x.DateTimeCreated).ToList();

            result.AddRange(notReviewedNotifications);
            result.AddRange(reviewedNotifications);

            return result.AsEnumerable();
        }
            

        public Domain.Entries.Notification.Notification GetNotificationById(Guid notificationId) =>
            _context.Notifications.FirstOrDefault(x => x.Id == notificationId);

        public async Task<bool> IsNotificationReviewed(Domain.Entries.Notification.Notification notification)
        {
            var user = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            var notificationReview =
                _context.UserNotifications.FirstOrDefault(x =>
                    x.AppUserId == user.Id && x.NotificationId == notification.Id);

            return notificationReview != null;
        }

        public async Task<bool> MarkAsReadByIdAsync(Guid notificationId)
        {
            var notification = _context.Notifications.FirstOrDefault(x => x.Id == notificationId);

            var user = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            if (notification is null || user is null)
                return false;

            var newUserNotification = new UserNotification
            {
                AppUserId = user.Id,
                AppUser = user,
                NotificationId = notification.Id,
                Notification = notification
            };

            _context.UserNotifications.Add(newUserNotification);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task MarkAllAsReadAsync()
        {
            var user = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            foreach (var notification in _context.Notifications)
            {
                var userNotification = _context.UserNotifications
                    .FirstOrDefault(x => x.AppUserId == user.Id && x.NotificationId == notification.Id);

                if (userNotification is null)
                {
                    var newNotification = new UserNotification
                    {
                        AppUserId = user.Id,
                        AppUser = user,
                        NotificationId = notification.Id,
                        Notification = notification
                    };

                    _context.UserNotifications.Add(newNotification);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteNotificationAsync(Guid notificationId)
        {
            var notification = _context.Notifications.FirstOrDefault(x => x.Id == notificationId);

            if(notification is null)
                return false;

            _context.Remove(notification);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<int> GetNewNotificationsCount()
        {
            int counter = 0;

            foreach (var notification in _context.Notifications)
                if (!await IsNotificationReviewed(notification))
                    counter++;

            return counter;
        }
    }
}
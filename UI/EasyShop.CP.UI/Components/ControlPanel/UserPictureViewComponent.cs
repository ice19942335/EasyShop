using EasyShop.Domain.Entries.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.CP.UI.Components.ControlPanel
{
    public class UserPictureViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public UserPictureViewComponent(UserManager<AppUser> userManager) => _userManager = userManager;

        public IViewComponentResult Invoke()
        {
            var appUser = _userManager.FindByEmailAsync(User.Identity.Name).Result;

            if (appUser is null)
                return View(null);

            return View("UserPicture", appUser.ProfileImage);
        }
    }
}

using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Enums;
using EasyShop.Domain.Enums.CP.Email;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ServerMonetization.CP.Components.ControlPanel.UserProfile
{
    public class EmailConfirmationViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public EmailConfirmationViewComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IViewComponentResult Invoke()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;

            if (user is null)
                return View("EmailConfirmStatus", EmailConfirmationEnum.SomethingWentWrong);

            return View("EmailConfirmStatus", user.EmailConfirmed ? EmailConfirmationEnum.EmailIsConfirmed : EmailConfirmationEnum.EmailNotConfirmed);
        }
    }
}

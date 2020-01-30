using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rust.MultiTenant.Shop.Extensions;

namespace Rust.MultiTenant.Shop.Components
{
    public class UserStatusViewComponent : ViewComponent
    {
        private readonly AuthenticationScheme[] _authenticationSchemes;

        public UserStatusViewComponent(IHttpContextAccessor httpContextAccessor)
        {
            _authenticationSchemes = httpContextAccessor.HttpContext.GetExternalProvidersAsync().Result;
        }

        public IViewComponentResult Invoke()
        {
            if (User.Identity.IsAuthenticated)
                return View("SignedIn");
            else
                return View("SignedOut", _authenticationSchemes.First(x => x.Name == "Steam"));
        }
    }
}

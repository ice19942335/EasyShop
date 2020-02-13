using System.Threading.Tasks;
using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Rust.MultiTenant.Shop.Extensions;

namespace Rust.MultiTenant.Shop.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> SignIn([FromForm] string provider)
        {
            // Note: the "provider" parameter corresponds to the external
            // authentication provider choosen by the user agent.
            if (string.IsNullOrWhiteSpace(provider))
            {
                return BadRequest();
            }

            if (!await HttpContext.IsProviderSupportedAsync(provider))
            {
                return BadRequest();
            }

            // Instruct the middleware corresponding to the requested external identity
            // provider to redirect the user agent to its own authorization endpoint.
            // Note: the authenticationScheme parameter must match the value configured in Startup.cs
            var ti = HttpContext.GetMultiTenantContext().TenantInfo;
            return Challenge(new AuthenticationProperties { RedirectUri = $"/{ti.Identifier}" }, provider);
        }

        public IActionResult SignOut()
        {
            // Instruct the cookies middleware to delete the local cookie created
            // when the user agent is redirected from the external identity provider
            // after a successful authentication flow (e.g Google or Facebook).

            var tenantInfo = HttpContext.GetMultiTenantContext().TenantInfo;
            var url = Url.Action("Store", "Store", null, HttpContext.Request.Scheme);

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectPermanent(url);
        }

        public IActionResult UserHaveToBeLoggedIn() => View();
    }
}

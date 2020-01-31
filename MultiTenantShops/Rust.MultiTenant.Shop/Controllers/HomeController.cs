using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Rust.MultiTenant.Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Store()
        {
            _logger.LogInformation("Hello, this is the index!");
            var tenantInfo = HttpContext.GetMultiTenantContext()?.TenantInfo;
            return View(tenantInfo);
        }
    }
}
using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Mvc;

namespace Rust.MultiTenant.Shop.Controllers
{
    public class HomeController : Controller
    {
        //[HttpGet("~/")]
        public ActionResult Index()
        {
            var tenantInfo = HttpContext.GetMultiTenantContext()?.TenantInfo;
            return View(tenantInfo);
        }
    }
}
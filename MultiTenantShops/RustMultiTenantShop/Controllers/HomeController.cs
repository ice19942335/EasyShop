using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MultiTenancyStrategy;
using MultiTenancyStrategy.Extensions;
using MultiTenancyStrategy.Models;
using MultiTenancyStrategy.Services;

namespace RustMultiTenantShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TenantAccessService<Tenant> _tenantAccessService;

        public HomeController(ILogger<HomeController> logger, TenantAccessService<Tenant> tenantAccessService)
        {
            _logger = logger;
            _tenantAccessService = tenantAccessService;
        }

        public async Task<IActionResult> Index()
        {
            var tenantService = await _tenantAccessService.GetTenantAsync();
            return Content(await Task.FromResult(HttpContext.GetTenant().Id));
        }
    }
}
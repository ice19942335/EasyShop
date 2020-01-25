using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MultiTenancyStrategy;
using MultiTenancyStrategy.Accessors;
using MultiTenancyStrategy.Accessors.Services;
using MultiTenancyStrategy.Extensions;
using MultiTenancyStrategy.Interfaces;
using MultiTenancyStrategy.Models;

namespace RustMultiTenantShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TenantAccessService<Tenant> _tenantAccessService;
        private readonly ITenantAccessor<Tenant> _tenantAccessor;

        public HomeController(ILogger<HomeController> logger, TenantAccessService<Tenant> tenantAccessService, ITenantAccessor<Tenant> tenantAccessor)
        {
            _logger = logger;
            _tenantAccessService = tenantAccessService;
            _tenantAccessor = tenantAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var tenantService = _tenantAccessor;
            return Content(await Task.FromResult(HttpContext.GetTenant().Id));
        }
    }
}
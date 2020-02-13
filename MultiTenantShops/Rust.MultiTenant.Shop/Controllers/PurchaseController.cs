using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.RustStore.Store.Order;
using Microsoft.AspNetCore.Mvc;

namespace Rust.MultiTenant.Shop.Controllers
{
    public class PurchaseController : Controller
    {
        public PurchaseController()
        {
            
        }

        [HttpPost]
        public IActionResult RustStandardItem([FromForm] RustStoreStandardItemOrder model)
        {
            throw new NotImplementedException();
        }
    }
}
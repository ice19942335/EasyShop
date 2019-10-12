using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.CP.UI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register() => View();

        public IActionResult Login() => View();

        public IActionResult LogOut() => RedirectToAction("Index", "Home");

        public IActionResult AccessDenied() => View();
    }
}
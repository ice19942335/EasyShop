using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using EasyShop.Domain.Entities.Identity;
using EasyShop.Domain.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyShop.CP.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            var date = new DateTime(model.Year, model.Day, Int32.Parse(model.Month));

            if (!ModelState.IsValid)
                return View(model);

            if (!model.Terms)
            {
                ModelState.AddModelError("Terms", "Please, accept terms of service");
                return View(model);
            }

            var newUser = new User
            {
                UserName = model.Firstname?? model.Email,
                Email = model.Email
            };
            var creationResult = await _userManager.CreateAsync(newUser, model.Password);

            if (creationResult.Succeeded)
            {
                await _signInManager.SignInAsync(newUser, false);

                return RedirectToAction("Index", "Home");
            }

            foreach (var error in creationResult.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }

        public IActionResult Login() => View();

        public IActionResult LogOut() => RedirectToAction("Index", "Home");

        public IActionResult PasswordReset() => View();

        public IActionResult AccessDenied() => View();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Interfaces.Services.CP.DevBlog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.CP.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DevBlogController : Controller
    {
        private readonly IDevBlogService _devBlogService;

        public DevBlogController(IDevBlogService devBlogService)
        {
            _devBlogService = devBlogService;
        }

        [AllowAnonymous]
        public IActionResult PostsList()
        {
            return View();
        }

        public async Task<IActionResult> EditPost(string postId)
        {
            return View();
        }

        public async Task<IActionResult> DeletePost(string postId)
        {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Admin, User")]
        public IActionResult IncrementLike()
        {
            throw new NotImplementedException();
        }
    }
}
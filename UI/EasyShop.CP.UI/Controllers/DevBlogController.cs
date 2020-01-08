using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.ControlPanel.DevBlog;
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
            var model = new DevBlogViewModel
            {
                Posts = _devBlogService.GetAllPosts().Select(x => new DevBlogPostViewModel
                {
                    Id = x.Id.ToString(),
                    Title = x.Title,
                    PostMessage = x.PostMessage,
                    ImgUrl = x.ImgUrl,
                    Link = x.Link,
                    LinkTitle = x.LinkTitle,
                    DateTimePosted = x.DateTimePosted,
                    LikesCounter = x.LikesCounter
                })
            };

            return View(model);
        }

        public IActionResult EditPost(string postId)
        {
            if (postId is null)
                return View(new EditDevBlogPostViewModel());

            var post = _devBlogService.GetPostById(Guid.Parse(postId));

            return View(new EditDevBlogPostViewModel
            {
                Id = post.Id.ToString(),
                Title = post.Title,
                PostMessage = post.PostMessage,
                ImgUrl = post.ImgUrl,
                Link = post.Link,
                LinkTitle = post.LinkTitle,
                DateTimePosted = post.DateTimePosted,
                LikesCounter = post.LikesCounter
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditPost([FromForm] EditDevBlogPostViewModel model)
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
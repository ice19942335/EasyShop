using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.Contracts.CP.Response;
using EasyShop.Domain.Enums.CP.DevBlog;
using EasyShop.Domain.ViewModels.CP.ControlPanel.DevBlog;
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
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToList();
                errors.ForEach(x => ModelState.AddModelError("", x));
                return View(model);
            }

            var result = await _devBlogService.UpdatePost(model);

            if (result == DevBlogPostUpdateResult.NotFound)
                return RedirectToAction("NotFoundPage", "Home");
            else if(result == DevBlogPostUpdateResult.Created)
                return RedirectToAction("PostsList");
            else if (result == DevBlogPostUpdateResult.Updated)
                return View(model);
            else 
                return RedirectToAction("SomethingWentWrong", "Home");
        }

        public async Task<IActionResult> DeletePost(string postId)
        {
            var result = await _devBlogService.DeletePost(Guid.Parse(postId));

            if (!result)
                return RedirectToAction("SomethingWentWrong", "Home");

            return RedirectToAction("PostsList");
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> IncrementLike(string postId)
        {
            if (!User.Identity.IsAuthenticated)
                return Ok(new IncrementLikesCounterResponse { Result = "NotAuthenticated" });

            var result = await _devBlogService.IncrementLike(Guid.Parse(postId));

            return Ok(new IncrementLikesCounterResponse { Result = result.ToString() });
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> UserHasAlreadyLikedThePost(string postId)
        {
            if(!User.Identity.IsAuthenticated)
                return Ok(new UserAlreadyLikedThePostResponse { Result = "NotAuthenticated" });

            var result = await _devBlogService.UserHasAlreadyLikedThePost(Guid.Parse(postId));

            return Ok(new UserAlreadyLikedThePostResponse { Result = result.ToString() });
        }
    }
}
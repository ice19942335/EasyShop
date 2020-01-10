using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.DevBlog;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Enums.DevBlog;
using EasyShop.Domain.ViewModels.ControlPanel.DevBlog;
using EasyShop.Interfaces.Services.CP.DevBlog;
using EasyShop.Interfaces.Services.CP.FileImage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EasyShop.Services.CP.DevBlog
{
    public class DevBlogService : IDevBlogService
    {
        private readonly EasyShopContext _context;
        private readonly IFileImageService _fileImageService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public DevBlogService(
            EasyShopContext context,
            IFileImageService fileImageService,
            IHttpContextAccessor httpContextAccessor,
            UserManager<AppUser> userManager)
        {
            _context = context;
            _fileImageService = fileImageService;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<DevBlogPostUpdateResult> UpdatePost(EditDevBlogPostViewModel model)
        {
            if (model.Id is null)
            {
                var newPost = new DevBlogPost
                {
                    Id = Guid.NewGuid(),
                    Title = model.Title,
                    PostMessage = model.PostMessage,
                    Link = model.Link,
                    LinkTitle = model.LinkTitle,
                    DateTimePosted = DateTime.Today,
                    LikesCounter = 0
                };

                if (model.ImageToUpload != null)
                    newPost.ImgUrl = await _fileImageService.SaveFile(model.ImageToUpload, "DevBlogImages");

                _context.Add(newPost);
                await _context.SaveChangesAsync();
                return DevBlogPostUpdateResult.Created;
            }

            var post = _context.DevBlogPosts.FirstOrDefault(x => x.Id == Guid.Parse(model.Id));

            if (post is null)
                return DevBlogPostUpdateResult.NotFound;

            post.Title = model.Title;
            post.PostMessage = model.PostMessage;
            post.LinkTitle = model.LinkTitle;
            post.Link = model.Link;
            post.ImgUrl = model.ImgUrl;

            if (model.ImageToUpload != null)
                post.ImgUrl = await _fileImageService.SaveFile(model.ImageToUpload, "DevBlogImages");

            _context.Update(post);
            await _context.SaveChangesAsync();
            return DevBlogPostUpdateResult.Updated;
        }

        public IEnumerable<DevBlogPost> GetAllPosts() => _context.DevBlogPosts.AsEnumerable();

        public DevBlogPost GetPostById(Guid postId) => _context.DevBlogPosts.FirstOrDefault(x => x.Id == postId);

        public async Task<bool> DeletePost(Guid postId)
        {
            var post = _context.DevBlogPosts.FirstOrDefault(x => x.Id == postId);

            if (post is null)
                return false;

            _context.Remove(post);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> IncrementLike(Guid postId)
        {
            var user = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            var post = GetPostById(postId);

            var likeEntry = _context.DevBlogPostsLikes
                .Include(x => x.AppUser)
                .Include(x => x.DevBlogPost)
                .FirstOrDefault(x => x.AppUserId == user.Id && x.DevBlogPostId == postId);

            if (likeEntry is null)
            {
                var newLikeEntry = new DevBlogPostsLike
                {
                    DevBlogPostId = postId,
                    DevBlogPost = post,
                    AppUserId = user.Id,
                    AppUser = user
                };

                post.LikesCounter += 1;

                _context.DevBlogPosts.Update(post);
                _context.DevBlogPostsLikes.Add(newLikeEntry);
                await _context.SaveChangesAsync();
                return true;
            }

            post.LikesCounter -= 1;

            _context.DevBlogPosts.Update(post);
            _context.DevBlogPostsLikes.Remove(likeEntry);
            await _context.SaveChangesAsync();
            return false;
        }

        public int GetLikesCount(Guid postId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UserHasAlreadyLikedThePost(Guid postId)
        {
            var user = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            var likeEntry = _context.DevBlogPostsLikes
                .Include(x => x.AppUser)
                .Include(x => x.DevBlogPost)
                .FirstOrDefault(x => x.AppUserId == user.Id && x.DevBlogPostId == postId);

            if (likeEntry is null)
                return false;

            return true;
        }
    }
}

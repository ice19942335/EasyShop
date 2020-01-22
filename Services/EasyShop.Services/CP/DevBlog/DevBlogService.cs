using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.DevBlog;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Enums.CP.DevBlog;
using EasyShop.Domain.ViewModels.CP.ControlPanel.DevBlog;
using EasyShop.Interfaces.Imgur;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly IImgUrService _imgUrService;

        public DevBlogService(
            EasyShopContext context,
            IFileImageService fileImageService,
            IHttpContextAccessor httpContextAccessor,
            UserManager<AppUser> userManager,
            IImgUrService imgUrService)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _imgUrService = imgUrService;
        }

        public DevBlogPostUpdateResult UpdatePost(ref EditDevBlogPostViewModel model)
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
                {
                    var imageUploadResult = _imgUrService.UploadImageAsync(model.ImageToUpload).Result;

                    if (imageUploadResult is null)
                        return DevBlogPostUpdateResult.Failed;

                    model.ImgUrl = imageUploadResult.Link;
                    newPost.ImgDeleteHash = imageUploadResult.DeleteHash;
                    newPost.ImgUrl = imageUploadResult.Link;
                }
                
                _context.Add(newPost); 
                _context.SaveChangesAsync();
                return DevBlogPostUpdateResult.Created;
            }

            var postId = model.Id;
            var post = _context.DevBlogPosts.FirstOrDefault(x => x.Id == Guid.Parse(postId));

            if (post is null)
                return DevBlogPostUpdateResult.NotFound;

            if (model.ImageToUpload != null)
            {
                _imgUrService.DeleteImageAsync(post.ImgDeleteHash);
                var imageUploadResult = _imgUrService.UploadImageAsync(model.ImageToUpload).Result;

                if (imageUploadResult is null)
                    return DevBlogPostUpdateResult.Failed;

                model.ImgUrl = imageUploadResult.Link;
                post.ImgDeleteHash = imageUploadResult.DeleteHash;
                post.ImgUrl = imageUploadResult.Link;
            }

            post.Title = model.Title;
            post.PostMessage = model.PostMessage;
            post.LinkTitle = model.LinkTitle;
            post.Link = model.Link;

            _context.Update(post);
            _context.SaveChangesAsync();
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

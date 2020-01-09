using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.DevBlog;
using EasyShop.Domain.Enums.DevBlog;
using EasyShop.Domain.ViewModels.ControlPanel.DevBlog;
using EasyShop.Interfaces.Services.CP.DevBlog;
using EasyShop.Interfaces.Services.CP.FileImage;
using Microsoft.AspNetCore.Authorization;

namespace EasyShop.Services.CP.DevBlog
{
    public class DevBlogService : IDevBlogService
    {
        private readonly EasyShopContext _context;
        private readonly IFileImageService _fileImageService;

        public DevBlogService(EasyShopContext context, IFileImageService fileImageService)
        {
            _context = context;
            _fileImageService = fileImageService;
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
                    DateTimePosted = DateTime.Today.Date,
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
            post.DateTimePosted = model.DateTimePosted;
            post.LikesCounter = model.LikesCounter;

            if (model.ImageToUpload != null)
                post.ImgUrl = await _fileImageService.SaveFile(model.ImageToUpload, "DevBlogImages");

            _context.Update(post);
            await _context.SaveChangesAsync();
            return DevBlogPostUpdateResult.Updated;
        }

        public IEnumerable<DevBlogPost> GetAllPosts() => _context.DevBlogPosts.AsEnumerable();

        public DevBlogPost GetPostById(Guid postId) => _context.DevBlogPosts.FirstOrDefault(x => x.Id == postId);

        public Task<bool> DeletePost(Guid postId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IncrementLike(Guid postId)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.DevBlog;
using EasyShop.Domain.ViewModels.ControlPanel.DevBlog;
using EasyShop.Interfaces.Services.CP.DevBlog;
using Microsoft.AspNetCore.Authorization;

namespace EasyShop.Services.CP.DevBlog
{
    public class DevBlogService : IDevBlogService
    {
        private readonly EasyShopContext _context;

        public DevBlogService(EasyShopContext context)
        {
            _context = context;
        }

        public Task<bool> UpdatePost(DevBlogPostViewModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DevBlogPost> GetAllPosts() => _context.DevBlogPosts.AsEnumerable();

        public DevBlogPost GetPostById(Guid postId)
        {
            throw new NotImplementedException();
        }

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

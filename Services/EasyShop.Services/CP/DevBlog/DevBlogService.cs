using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.DevBlog;
using EasyShop.Domain.ViewModels.ControlPanel.DevBlog;
using EasyShop.Interfaces.Services.CP.DevBlog;

namespace EasyShop.Services.CP.DevBlog
{
    public class DevBlogService : IDevBlogService
    {
        public Task<bool> UpdatePost(DevBlogPostViewModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DevBlogPost> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePost(Guid postId)
        {
            throw new NotImplementedException();
        }
    }
}

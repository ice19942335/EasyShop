using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.DevBlog;

namespace EasyShop.Interfaces.Services.CP.DevBlog
{
    public interface IDevBlogService
    {
        Task<bool> UpdatePost(DevBlogPostViewModel model);

        IEnumerable<DevBlogPost> GetAllPosts();

        Task<bool> DeletePost(Guid postId);
    }
}

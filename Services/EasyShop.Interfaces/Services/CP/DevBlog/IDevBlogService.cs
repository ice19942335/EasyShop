using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.DevBlog;
using EasyShop.Domain.ViewModels.ControlPanel.DevBlog;

namespace EasyShop.Interfaces.Services.CP.DevBlog
{
    public interface IDevBlogService
    {
        Task<bool> UpdatePost(DevBlogPostViewModel model);

        IEnumerable<DevBlogPost> GetAllPosts();

        DevBlogPost GetPostById(Guid postId);

        Task<bool> DeletePost(Guid postId);

        Task<bool> IncrementLike(Guid postId);
    }
}

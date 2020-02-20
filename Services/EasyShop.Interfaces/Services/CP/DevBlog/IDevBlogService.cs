using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.DevBlog;
using EasyShop.Domain.Enums.CP.DevBlog;
using EasyShop.Domain.ViewModels.ControlPanel.DevBlog;

namespace EasyShop.Interfaces.Services.CP.DevBlog
{
    public interface IDevBlogService
    {
        DevBlogPostUpdateResult UpdatePost(ref EditDevBlogPostViewModel model);

        IEnumerable<DevBlogPost> GetAllPosts();

        DevBlogPost GetPostById(Guid postId);

        Task<bool> DeletePost(Guid postId);

        Task<bool> IncrementLike(Guid postId);

        int GetLikesCount(Guid postId);

        Task<bool> UserHasAlreadyLikedThePost(Guid postId);
    }
}

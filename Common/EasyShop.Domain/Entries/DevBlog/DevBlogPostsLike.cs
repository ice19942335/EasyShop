using System;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Entries.Identity;

namespace EasyShop.Domain.Entries.DevBlog
{
    [Table("DevBlogPostsLikes")]
    public class DevBlogPostsLike
    {
        public Guid DevBlogPostId { get; set; }
        public DevBlogPost DevBlogPost { get; set; }


        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
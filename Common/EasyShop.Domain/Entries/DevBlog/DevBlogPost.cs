using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text;

namespace EasyShop.Domain.Entries.DevBlog
{
    [Table("DevBlogPosts")]
    public class DevBlogPost
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string PostMessage { get; set; }

        public string ImgUrl { get; set; }

        public string ImgDeleteHash { get; set; }

        public string Link { get; set; }

        public string LinkTitle { get; set; }

        [Required]
        public DateTime DateTimePosted { get; set; }

        [Required]
        public int LikesCounter { get; set; }

        public ICollection<DevBlogPostsLike> DevBlogPostsLikes { get; set; }
    }
}

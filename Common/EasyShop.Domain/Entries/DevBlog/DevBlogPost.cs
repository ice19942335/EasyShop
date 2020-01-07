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

        [Required]
        public string Title { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public string ImgUrl { get; set; }

        public string Link { get; set; }

        public string LinkTitle { get; set; }

        [Required]
        public DateTime DateTimePosted { get; set; }

        [Required]
        public int LikesCounter { get; set; }

        [Required]
        public ICollection<DevBlogPostsLike> DevBlogPostsLikes { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Entries.Identity;

namespace EasyShop.Domain.ViewModels.ControlPanel.DevBlog
{
    public class DevBlogPostViewModel
    {
        public string Id { get; set; }

        public AppUser AppUser { get; set; }

        public string Title { get; set; }

        public string PostMessage { get; set; }

        public string ImgUrl { get; set; }

        public DateTime DateTimePosted { get; set; }

        public int LikesCounter { get; set; }
    }
}

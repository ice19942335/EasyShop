using System;

namespace EasyShop.Domain.ViewModels.CP.ControlPanel.DevBlog
{
    public class DevBlogPostViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string PostMessage { get; set; }

        public string ImgUrl { get; set; }

        public string Link { get; set; }

        public string LinkTitle { get; set; }

        public DateTime DateTimePosted { get; set; }

        public int LikesCounter { get; set; }
    }
}

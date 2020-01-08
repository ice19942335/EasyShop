using System;
using Microsoft.AspNetCore.Http;

namespace EasyShop.Domain.ViewModels.ControlPanel.DevBlog
{
    public class EditDevBlogPostViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string PostMessage { get; set; }

        public string ImgUrl { get; set; }

        public IFormFile ImageToUpload { get; set; }

        public string Link { get; set; }

        public string LinkTitle { get; set; }

        public DateTime DateTimePosted { get; set; }

        public int LikesCounter { get; set; }
    }
}

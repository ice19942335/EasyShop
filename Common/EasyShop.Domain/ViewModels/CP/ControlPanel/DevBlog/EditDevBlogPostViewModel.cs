using System;
using System.ComponentModel.DataAnnotations;
using EasyShop.Domain.Enums.CP.DevBlog;
using Microsoft.AspNetCore.Http;

namespace EasyShop.Domain.ViewModels.CP.ControlPanel.DevBlog
{
    public class EditDevBlogPostViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "The post title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The post message is required.")]
        public string PostMessage { get; set; }

        public string ImgUrl { get; set; }

        public IFormFile ImageToUpload { get; set; }

        public string Link { get; set; }

        public string LinkTitle { get; set; }

        public DateTime DateTimePosted { get; set; }

        public int LikesCounter { get; set; }

        public DevBlogPostUpdateResult Status { get; set; } = DevBlogPostUpdateResult.Default;
    }
}

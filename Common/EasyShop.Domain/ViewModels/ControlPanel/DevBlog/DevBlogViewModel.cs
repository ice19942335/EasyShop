using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShop.Domain.ViewModels.ControlPanel.DevBlog
{
    public class DevBlogViewModel
    {
        public IEnumerable<DevBlogPostViewModel> Posts { get; set; }
    }
}

using System.Collections.Generic;

namespace EasyShop.Domain.ViewModels.ControlPanel.DevBlog
{
    public class DevBlogViewModel
    {
        public IEnumerable<DevBlogPostViewModel> Posts { get; set; }

        public PageViewModel.PageViewModel Pages { get; set; }
    }
}

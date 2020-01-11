using System.Collections.Generic;

namespace EasyShop.Domain.ViewModels.CP.ControlPanel.DevBlog
{
    public class DevBlogViewModel
    {
        public IEnumerable<DevBlogPostViewModel> Posts { get; set; }
    }
}

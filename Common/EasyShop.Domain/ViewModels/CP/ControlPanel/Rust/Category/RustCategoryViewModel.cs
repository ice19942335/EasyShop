using System.ComponentModel.DataAnnotations;

namespace EasyShop.Domain.ViewModels.CP.ControlPanel.Rust.Category
{
    public class RustCategoryViewModel
    {
        public string Id { get; set; }

        [Required]
        public int Index { get; set; }

        public string ShopId { get; set; }

        [Required]
        public string Name { get; set; }

        public int? AssignedItemsCount { get; set; }
    }
}
namespace EasyShop.Domain.ViewModels.Shop.Rust
{
    public class RustCategoryViewModel
    {
        public string Id { get; set; }

        public int Index { get; set; }

        public string ShopId { get; set; }

        public string Name { get; set; }

        public int? AssignedItemsCount { get; set; }
    }
}
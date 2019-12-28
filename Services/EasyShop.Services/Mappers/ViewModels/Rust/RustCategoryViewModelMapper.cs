using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Entries.Rust;
using EasyShop.Domain.ViewModels.Rust.Category;

namespace EasyShop.Services.Mappers.ViewModels.Rust
{
    public static class RustCategoryViewModelMapper
    {
        public static RustCategoryViewModel CreateRustCategoryViewModel(this RustCategory category, int? assignedItemsCount = null)
        {
            var model = category.CopyToCategoryRustShopViewModel(assignedItemsCount);
            return model;
        }

        private static RustCategoryViewModel CopyToCategoryRustShopViewModel(this RustCategory category, int? assignedItemsCount = null)
        {
            var model = new RustCategoryViewModel
            {
                Id = category.Id.ToString(),
                Index = category.Index,
                ShopId = category.Shop.Id.ToString(),
                Name = category.Name,
                AssignedItemsCount = assignedItemsCount
            };

            return model;
        }
    }
}

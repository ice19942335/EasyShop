using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Entries.Items.RustItems;
using EasyShop.Domain.ViewModels.Shop.Rust;

namespace EasyShop.Services.Mappers.ViewModels.Rust
{
    public static class RustCategoryViewModelMapper
    {
        public static RustCategoryViewModel CreateRustCategoryViewModel(this RustCategory category, int assignedItemsCount)
        {
            var model = category.CopyToCategoryRustShopViewModel(assignedItemsCount);
            return model;
        }

        private static RustCategoryViewModel CopyToCategoryRustShopViewModel(this RustCategory category, int assignedItemsCount)
        {
            var model = new RustCategoryViewModel
            {
                Id = category.Id.ToString(),
                Name = category.Name,
                AssignedItemsCount = assignedItemsCount
            };

            return model;
        }
    }
}

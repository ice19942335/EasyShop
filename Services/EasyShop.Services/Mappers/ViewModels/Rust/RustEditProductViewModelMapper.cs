using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyShop.Domain.Entries.Items.RustItems;
using EasyShop.Domain.ViewModels.Shop.Rust;

namespace EasyShop.Services.Mappers.ViewModels.Rust
{
    public static class RustEditProductViewModelMapper
    {
        public static RustEditProductViewModel CreateRustEditProductViewModel(this RustProduct product, IEnumerable<RustCategory> userCategories)
        {
            var model = product.CopyToEditProductViewModel(userCategories);
            return model;
        }

        private static RustEditProductViewModel CopyToEditProductViewModel(this RustProduct product, IEnumerable<RustCategory> userCategories)
        {
            var model = new RustEditProductViewModel
            {
                Id = product.Id.ToString(),
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Discount = product.Discount,
                Amount = product.Amount,
                BlockedTill = product.BlockedTill == default ? "" : string.Format("{0:M/d/yyyy}", product.BlockedTill),
                CurrentCategoryName = product.RustCategory.Name,
                RustCategories = userCategories.Select(x => x.CreateRustCategoryViewModel()),
                ShowInShop = product.ShowInShop,
                ImgUrl = product.RustItem.ImgUrl
            };

            return model;
        }
    }
}

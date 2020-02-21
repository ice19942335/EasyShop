using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyShop.Domain.Entries.Rust;
using EasyShop.Domain.ViewModels.ControlPanel.Rust.Product;

namespace EasyShop.Services.Mappers.ViewModels.Rust
{
    public static class RustProductEditViewModelMapper
    {
        public static RustProductEditViewModel CreateRustEditProductViewModel(this RustProduct product, IEnumerable<RustCategory> userCategories)
        {
            var model = product.CopyToEditProductViewModel(userCategories);
            return model;
        }

        private static RustProductEditViewModel CopyToEditProductViewModel(this RustProduct product, IEnumerable<RustCategory> userCategories)
        {
            var model = new RustProductEditViewModel
            {
                Id = product.Id.ToString(),
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Discount = product.Discount,
                Amount = product.ItemsPerStack,
                BlockedTill = product.BlockedTill == default ? "" : string.Format("{0:M/d/yyyy}", product.BlockedTill),
                CurrentCategoryName = product.RustCategory.Name,
                RustCategories = userCategories.Select(x => x.CreateRustCategoryViewModel()),
                ShowInShop = product.ShowInShop,
                ImgUrl = product.RustItem.ImgUrl,
                Index = product.Index
            };

            return model;
        }
    }
}

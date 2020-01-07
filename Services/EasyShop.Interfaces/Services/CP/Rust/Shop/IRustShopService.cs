using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Rust;
using EasyShop.Domain.Enums.CP.Rust;
using EasyShop.Domain.ViewModels.ControlPanel.Rust.Shop;
using EasyShop.Domain.ViewModels.ControlPanel.Shop;

namespace EasyShop.Interfaces.Services.CP.Rust.Shop
{
    public interface IRustShopService
    {
        Task<RustCreateShopResult> CreateShopAsync(CreateShopViewModel model);

        Task<Domain.Entries.Shop.Shop> UpdateShopAsync(RustShopEditMainSettingsViewModel model);

        IEnumerable<RustCategory> GetAllAssignedCategoriesToShopByShopId(Guid shopId);

        int GetAssignedUserItemsCountToACategoryInShop(Guid categoryId, Guid shopId);

        Task<(RustCategory, RustEditCategoryResult)> UpdateCategoryAsync(RustShopViewModel model);

        RustCategory GetCategoryById(Guid categoryId);

        Task<bool> DeleteCategory(Guid categoryId);

        Task<bool> DeleteShopAsync(Guid shopId);

        (List<RustCategory>, List<RustProduct>) GetDefaultCategoriesWithProducts(AppUser user,
            Domain.Entries.Shop.Shop shop);

        Task<bool> SetDefaultProductsAsync(AppUser user, Domain.Entries.Shop.Shop shop);

        IEnumerable<RustProduct> GetAllAssignedProductsToAShopByShopId(Guid shopId);

        RustProduct GetProductById(Guid productId);

        Task<RustEditProductResult> UpdateRustProductAsync(RustShopViewModel model);
    }
}

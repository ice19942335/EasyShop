using System.Collections.Generic;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Rust;

namespace EasyShop.Interfaces.Services.CP.Rust.Data
{
    public interface IRustDefaultCategoriesWithItemsService
    {
        (List<RustCategory>, List<RustProduct>) CreateDefaultCategoriesWithItems(
            AppUser user,
            Domain.Entries.Shop.Shop shop,
            List<RustCategory> defaultCategories,
            List<RustItem> defaultRustItems);
    }
}

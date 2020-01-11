using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShop.Domain.Enums.CP.ContactUs.BugReports
{
    public enum BugReportCategoriesEnum
    {
        //Common
        CpShopCreationBug,
        CpShopsManagerBug,

        //RustShop
        CpRustShopStatsBug,
        CpRustShopMainSettingUpdatingBug,
        CpRustShopProductUpdatingBug,
        CpRustShopCategoriesResetBug,
        CpRustShopCategoryCreationBug,
        CpRustShopCategoryUpdatingBug,
        CpRustShopServerManagerBug,
        CpRustShopServerCreationBug,

        //Other
        Other
    }
}

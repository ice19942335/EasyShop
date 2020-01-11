using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShop.Domain.Enums.CP.ContactUs.BugReports
{
    public enum BugReportCategoriesEnum
    {
        //Common
        Cp_Shop_creation_bug,
        Cp_Shop_manager_bug,

        //RustShop
        Cp_Rust_shop_stats_bug,
        Cp_Rust_shop_main_setting_update_bug,
        Cp_Rust_shop_product_update_bug,
        Cp_Rust_shop_categories_reset_bug,
        Cp_Rust_shop_category_creation_bug,
        Cp_Rust_shop_category_update_bug,
        Cp_Rust_shop_server_manager_bug,
        Cp_Rust_shop_server_creation_bug,

        //Cp_Other
        Cp_Other
    }
}

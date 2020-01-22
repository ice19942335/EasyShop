using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using EasyShop.Domain.Enums.CP.ContactUs.BugReports;
using EasyShop.Domain.ViewModels.CP.ViewModelValidation;
using Microsoft.AspNetCore.Http;

namespace EasyShop.Domain.ViewModels.CP.ContactUs
{
    public class CreateBugReportViewModel
    {
        [PictureToUploadValidation(new string[] { "png", "jpg", "jpeg" })]
        public IFormFile ImageToUpload { get; set; }

        [Required(ErrorMessage = "The title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please add a few words about bug or error.")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The bug category is required.")]
        public int SelectedCategory { get; set; }

        public List<BugReportCategoriesEnum> Categories { get; set; } = new List<BugReportCategoriesEnum>
        {
            //Common
            BugReportCategoriesEnum.Cp_Shop_creation_bug,
            BugReportCategoriesEnum.Cp_Shop_manager_bug,

            //RustShop
            BugReportCategoriesEnum.Cp_Rust_shop_stats_bug,
            BugReportCategoriesEnum.Cp_Rust_shop_main_settings_update_bug,
            BugReportCategoriesEnum.Cp_Rust_shop_product_update_bug,
            BugReportCategoriesEnum.Cp_Rust_shop_categories_reset_bug,
            BugReportCategoriesEnum.Cp_Rust_shop_category_creation_bug,
            BugReportCategoriesEnum.Cp_Rust_shop_category_update_bug,
            BugReportCategoriesEnum.Cp_Rust_shop_server_manager_bug,
            BugReportCategoriesEnum.Cp_Rust_shop_server_creation_bug,

            //Cp_Other
            BugReportCategoriesEnum.Cp_Other
        };
    }
}


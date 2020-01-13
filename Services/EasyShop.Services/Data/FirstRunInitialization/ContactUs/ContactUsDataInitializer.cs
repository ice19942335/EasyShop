using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.ContactUs;
using EasyShop.Domain.Entries.ContactUs.BugReports;
using EasyShop.Domain.Enums.CP.ContactUs;
using EasyShop.Domain.Enums.CP.ContactUs.BugReports;

namespace EasyShop.Services.Data.FirstRunInitialization.ContactUs
{
    public class ContactUsDataInitializer
    {
        private readonly List<ReportResponseStatus> _reportResponseStatuses = new List<ReportResponseStatus>
        {
            new ReportResponseStatus
            {
                Id = Guid.NewGuid(),
                Status = ReportResponseStatusEnum.WaitingForReview
            },
            new ReportResponseStatus
            {
                Id = Guid.NewGuid(),
                Status = ReportResponseStatusEnum.Reviewed
            },
            new ReportResponseStatus
            {
                Id = Guid.NewGuid(),
                Status = ReportResponseStatusEnum.Closed
            }
        };
        private readonly List<BugReportCategory> _bugReportCategories = new List<BugReportCategory>
        {
            new BugReportCategory
            {
                Id = Guid.NewGuid(),
                Category = BugReportCategoriesEnum.Cp_Other
            },
            new BugReportCategory
            {
                Id = Guid.NewGuid(),
                Category = BugReportCategoriesEnum.Cp_Rust_shop_categories_reset_bug
            },
            new BugReportCategory
            {
                Id = Guid.NewGuid(),
                Category = BugReportCategoriesEnum.Cp_Rust_shop_category_creation_bug
            },
            new BugReportCategory
            {
                Id = Guid.NewGuid(),
                Category = BugReportCategoriesEnum.Cp_Rust_shop_category_update_bug
            },
            new BugReportCategory
            {
                Id = Guid.NewGuid(),
                Category = BugReportCategoriesEnum.Cp_Rust_shop_main_setting_update_bug
            },
            new BugReportCategory
            {
                Id = Guid.NewGuid(),
                Category = BugReportCategoriesEnum.Cp_Rust_shop_product_update_bug
            },
            new BugReportCategory
            {
                Id = Guid.NewGuid(),
                Category = BugReportCategoriesEnum.Cp_Rust_shop_server_creation_bug
            },
            new BugReportCategory
            {
                Id = Guid.NewGuid(),
                Category = BugReportCategoriesEnum.Cp_Rust_shop_server_manager_bug
            },
            new BugReportCategory
            {
                Id = Guid.NewGuid(),
                Category = BugReportCategoriesEnum.Cp_Rust_shop_stats_bug
            },
            new BugReportCategory
            {
                Id = Guid.NewGuid(),
                Category = BugReportCategoriesEnum.Cp_Shop_creation_bug
            },
            new BugReportCategory
            {
                Id = Guid.NewGuid(),
                Category = BugReportCategoriesEnum.Cp_Shop_manager_bug
            },
            new BugReportCategory
            {
                Id = Guid.NewGuid(),
                Category = BugReportCategoriesEnum.Cp_Shop_creation_bug
            },
        };
        private readonly EasyShopContext _context;

        public ContactUsDataInitializer(EasyShopContext context) => _context = context;

        public async Task Initialize()
        {
            await _context.ReportResponseStatuses.AddRangeAsync(_reportResponseStatuses);
            await _context.BugReportCategories.AddRangeAsync(_bugReportCategories);

            await _context.SaveChangesAsync();
        }
    }
}

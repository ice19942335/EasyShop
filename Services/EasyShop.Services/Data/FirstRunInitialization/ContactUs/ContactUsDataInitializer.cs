using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly List<ReportStatus> _reportStatuses = new List<ReportStatus>
        {
            new ReportStatus
            {
                Id = Guid.NewGuid(),
                Index = ReportStatusEnum.WaitingForReview,
                Description = "Waiting for review"
            },
            new ReportStatus
            {
                Id = Guid.NewGuid(),
                Index = ReportStatusEnum.Reviewed,
                Description = "Reviewed"
            },
            new ReportStatus
            {
                Id = Guid.NewGuid(),
                Index = ReportStatusEnum.Closed,
                Description = "Closed"
            }
        };
        private readonly List<BugReportCategory> _bugReportCategories = new List<BugReportCategory>
        {
            new BugReportCategory
            {
                Id = Guid.NewGuid(),
                Index = BugReportCategoriesEnum.Cp_Shop_creation_bug,
                Description = "Shop creation bug"
            },
            new BugReportCategory
            {
                Id = Guid.NewGuid(),
                Index = BugReportCategoriesEnum.Cp_Shop_manager_bug,
                Description = "Shop manager bug"
            },
            new BugReportCategory
            {
                Id = Guid.NewGuid(),
                Index = BugReportCategoriesEnum.Cp_Rust_shop_stats_bug,
                Description = "Rust shop stats bug"
            },
            new BugReportCategory
            {
                Id = Guid.NewGuid(),
                Index = BugReportCategoriesEnum.Cp_Rust_shop_main_settings_update_bug,
                Description = "Rust shop main settings update bug"
            },
            new BugReportCategory
            {
                Id = Guid.NewGuid(),
                Index = BugReportCategoriesEnum.Cp_Rust_shop_product_update_bug,
                Description = "Rust shop product update bug"
            },
            new BugReportCategory
            {
                Id = Guid.NewGuid(),
                Index = BugReportCategoriesEnum.Cp_Rust_shop_categories_reset_bug,
                Description = "Rust shop categories reset bug"
            },
            new BugReportCategory
            {
                Id = Guid.NewGuid(),
                Index = BugReportCategoriesEnum.Cp_Rust_shop_category_creation_bug,
                Description = "Rust shop category creation bug"
            },
            new BugReportCategory
            {
                Id = Guid.NewGuid(),
                Index = BugReportCategoriesEnum.Cp_Rust_shop_category_update_bug,
                Description = "Rust shop category update bug"
            },
            new BugReportCategory
            {
                Id = Guid.NewGuid(),
                Index = BugReportCategoriesEnum.Cp_Rust_shop_server_manager_bug,
                Description = "Rust shop server manager bug"
            },
            new BugReportCategory
            {
                Id = Guid.NewGuid(),
                Index = BugReportCategoriesEnum.Cp_Rust_shop_server_creation_bug,
                Description = "Rust shop server creation bug"
            },
            new BugReportCategory
            {
            Id = Guid.NewGuid(),
            Index = BugReportCategoriesEnum.Cp_Other,
            Description = "Other"
            }
        };

        private readonly EasyShopContext _context;

        public ContactUsDataInitializer(EasyShopContext context) => _context = context;

        public async Task Initialize()
        {
            if (!_context.ReportStatus.Any())
            {
                await _context.ReportStatus.AddRangeAsync(_reportStatuses);
                await _context.BugReportCategories.AddRangeAsync(_bugReportCategories);

                await _context.SaveChangesAsync();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using Microsoft.AspNetCore.Identity;

namespace EasyShop.Services.Data.FirstRunInitialization.RustShopDataInitialization
{
    public class RustDefaultDataInitialization
    {
        private readonly EasyShopContext _dbContext;

        //private readonly List<string> _defaultItemTypes = new List<string>
        //{
        //    "Weapon",
        //    "Resources",
        //    "Ammunition",
        //    "Clothing",
        //    "Constructions",
        //    "Tools",
        //    "Medicines",
        //    "Food",
        //    "Electricity",
        //    "Components",
        //    "Holidays",
        //    "Other"
        //};

        public RustDefaultDataInitialization(EasyShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitializeDefaultCategories()
        {

        }
    }
}

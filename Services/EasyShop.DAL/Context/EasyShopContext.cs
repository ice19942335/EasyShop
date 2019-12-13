using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Entries.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyShop.DAL.Context
{
    public class EasyShopContext : IdentityDbContext<AppUser>
    {
        //Tables

        //Constructor
        public EasyShopContext(DbContextOptions<EasyShopContext> options) : base(options) { }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using EasyShop.Domain.Entries.ContactUs;
using EasyShop.Domain.Entries.ContactUs.BugReports;
using EasyShop.Domain.Entries.ContactUs.CollaborationReports;
using EasyShop.Domain.Entries.ContactUs.GeneralSupportReports;
using EasyShop.Domain.Entries.DevBlog;
using EasyShop.Domain.Entries.GameType;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Notification;
using EasyShop.Domain.Entries.Payment.PayPal;
using EasyShop.Domain.Entries.Rust;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Domain.Entries.Tariff;
using EasyShop.Domain.Entries.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EasyShop.DAL.Context
{
    public class EasyShopContext : IdentityDbContext<AppUser>
    {
        //Tariffs
        public DbSet<Tariff> Tariffs { get; set; }
        public DbSet<TariffOption> TariffOptions { get; set; }
        public DbSet<TariffOptionDescription> TariffOptionsDescriptions { get; set; }
        public DbSet<UserTariff> UserTariffs { get; set; }


        //Shops
        public DbSet<UserShop> UserShops { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<GameType> GameTypes { get; set; }


        //Rust
        public DbSet<RustServer> RustServers { get; set; }
        public DbSet<RustItem> RustItems { get; set; }
        public DbSet<RustItemType> RustItemTypes { get; set; }
        public DbSet<RustProduct> RustUserItems { get; set; }
        public DbSet<RustCategory> RustCategories { get; set; }
        public DbSet<RustPurchasedItem> RustPurchasedItems { get; set; }
        public DbSet<RustServerMap> RustServerMaps { get; set; }
        public DbSet<RustPurchaseStats> RustPurchaseStats { get; set; }


        //Users
        public DbSet<SteamUser> RustUsers { get; set; }


        //DevBlog
        public DbSet<DevBlogPost> DevBlogPosts { get; set; }
        public DbSet<DevBlogPostsLike> DevBlogPostsLikes { get; set; }


        //SteamUser SteamUserShop
        public DbSet<SteamUser> SteamUsers { get; set; }
        public DbSet<SteamUserShop> SteamUsersShops { get; set; }


        //ContactUs
        public DbSet<BugReport> BugReports { get; set; }
        public DbSet<BugReportCategory> BugReportCategories { get; set; }

        public DbSet<GeneralSupportReport> GeneralSupportReports { get; set; }
        public DbSet<GeneralSupportReportCategory> GeneralSupportReportCategories { get; set; }

        public DbSet<CollaborationReport> CollaborationReports { get; set; }
        public DbSet<ReportStatus> ReportStatus { get; set; }


        //Notification
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }


        //PayPalPayments
        public DbSet<PayPalCreatedPayment> PayPalCreatedPayments { get; set; }
        public DbSet<PayPalExecutedPayment> PayPalExecutedPayments { get; set; }


        //Constructor
        public EasyShopContext(DbContextOptions<EasyShopContext> options) : base(options) { }


        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region ManyToMany

            //AppUser -----------------------------------------------------------
            modelBuilder.Entity<AppUser>(x =>
            {
                x.Property(u => u.PurchasedTariffs);

                x.Property(u => u.PurchasedTariffs)
                    .HasConversion(
                        x => JsonConvert.SerializeObject(x, Formatting.None),
                        s => JsonConvert.DeserializeObject<Dictionary<Tariff, DateTime>>(s))
                    .HasMaxLength(10000);
            });
            //===================================================================

            //TariffOption ------------------------------------------------------
            modelBuilder.Entity<TariffOption>()
                .HasKey(x => new {x.TariffOptionDescriptionId, x.TariffId});

            modelBuilder.Entity<TariffOption>()
                .HasOne(x => x.TariffOptionDescription)
                .WithMany(x => x.TariffOptions)
                .HasForeignKey(x => x.TariffOptionDescriptionId);
            
            modelBuilder.Entity<TariffOption>()
                .HasOne(x => x.Tariff)
                .WithMany(x => x.TariffOptions)
                .HasForeignKey(x => x.TariffId);
            //===================================================================

            //UserTariff --------------------------------------------------------
            modelBuilder.Entity<UserTariff>()
                .HasKey(x => new { x.AppUserId, x.TariffId });

            modelBuilder.Entity<UserTariff>()
                .HasOne(x => x.AppUser)
                .WithMany(x => x.UserTariffs)
                .HasForeignKey(x => x.AppUserId);

            modelBuilder.Entity<UserTariff>()
                .HasOne(x => x.Tariff)
                .WithMany(x => x.UserTariffs)
                .HasForeignKey(x => x.TariffId);
            //===================================================================

            //UserShop ----------------------------------------------------------
            modelBuilder.Entity<UserShop>()
                .HasKey(x => new { x.AppUserId, x.ShopId });

            modelBuilder.Entity<UserShop>()
                .HasOne(x => x.Shop)
                .WithMany(x => x.UserShops)
                .HasForeignKey(x => x.ShopId);

            modelBuilder.Entity<UserShop>()
                .HasOne(x => x.AppUser)
                .WithMany(x => x.UserShops)
                .HasForeignKey(x => x.AppUserId);
            //===================================================================

            //DevBlogPostsLike --------------------------------------------------
            modelBuilder.Entity<DevBlogPostsLike>()
                .HasKey(x => new { x.AppUserId, x.DevBlogPostId });

            modelBuilder.Entity<DevBlogPostsLike>()
                .HasOne(x => x.DevBlogPost)
                .WithMany(x => x.DevBlogPostsLikes)
                .HasForeignKey(x => x.DevBlogPostId);

            modelBuilder.Entity<DevBlogPostsLike>()
                .HasOne(x => x.AppUser)
                .WithMany(x => x.DevBlogPostsLikes)
                .HasForeignKey(x => x.AppUserId);
            //===================================================================

            //UserNotification --------------------------------------------------
            modelBuilder.Entity<UserNotification>()
                .HasKey(x => new { x.AppUserId, x.NotificationId });

            modelBuilder.Entity<UserNotification>()
                .HasOne(x => x.Notification)
                .WithMany(x => x.UserNotifications)
                .HasForeignKey(x => x.NotificationId);

            modelBuilder.Entity<UserNotification>()
                .HasOne(x => x.AppUser)
                .WithMany(x => x.UserNotifications)
                .HasForeignKey(x => x.AppUserId);
            //===================================================================

            #endregion

            #region OnDeleteion SetNull

            //RustPurchaseStats
            modelBuilder.Entity<RustPurchaseStats>()
                .HasOne(x => x.AppUser)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<RustPurchaseStats>()
                .HasOne(x => x.RustPurchasedItem)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<RustPurchaseStats>()
                .HasOne(x => x.Shop)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            //RustPurchasedItems
            modelBuilder.Entity<RustPurchasedItem>()
                .HasOne(x => x.SteamUser)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<RustPurchasedItem>()
                .HasOne(x => x.RustItem)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            //PayPalCreatedPayments
            modelBuilder.Entity<PayPalCreatedPayment>()
                .HasOne(x => x.Shop)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<RustPurchasedItem>()
                .HasOne(x => x.SteamUser)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            //PayPalExecutedPayment
            modelBuilder.Entity<PayPalExecutedPayment>()
                .HasOne(x => x.Shop)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<PayPalExecutedPayment>()
                .HasOne(x => x.SteamUser)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            //SteamUserShops
            modelBuilder.Entity<SteamUserShop>()
                .HasOne(x => x.SteamUser)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<SteamUserShop>()
                .HasOne(x => x.Shop)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            #endregion
        }
    }
}



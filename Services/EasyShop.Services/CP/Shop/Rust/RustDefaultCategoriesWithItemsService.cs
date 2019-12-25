﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Items.RustItems;
using EasyShop.Interfaces.Services.CP.Shop.Rust;

namespace EasyShop.Services.CP.Shop.Rust
{
    public class RustDefaultCategoriesWithItemsService : IRustDefaultCategoriesWithItemsService
    {
        public async Task<(List<RustCategory>, List<RustProduct>)> CreateDefaultCategoriesWithItems(
            AppUser user,
            Domain.Entries.Shop.Shop shop,
            List<RustCategory> defaultCategories,
            List<RustItem> defaultRustItems)
        {
            var userDefaultCategories = defaultCategories.Select(x => new RustCategory
            {
                Id = Guid.NewGuid(),
                Index = x.Index,
                Name = x.Name,
                AppUser = user,
                Shop = shop
            }).ToList();

            var userItemsWeapons = new List<RustProduct>
            {
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Hunting Bow"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Hunting Bow",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Crossbow"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Crossbow",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Timed Explosive Charge"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Timed Explosive Charge",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Beancan Grenade"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Beancan Grenade",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "F1 Grenade"),
                    Shop = shop,
                    AppUser = user,
                    Name = "F1 Grenade",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "M249"),
                    Shop = shop,
                    AppUser = user,
                    Name = "M249",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Longsword"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Longsword",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Mace"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Mace",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Machete"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Machete",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Semi-Automatic Pistol"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Semi-Automatic Pistol",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Assault Rifle"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Assault Rifle",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Bolt Action Rifle"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Bolt Action Rifle",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Semi-Automatic Rifle"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Semi-Automatic Rifle",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Rocket Launcher"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Rocket Launcher",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Waterpipe Shotgun"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Waterpipe Shotgun",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Custom SMG"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Custom SMG",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Thompson"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Thompson",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Flame Thrower"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Flame Thrower",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "LR-300 Assault Rifle"),
                    Shop = shop,
                    AppUser = user,
                    Name = "LR-300 Assault Rifle",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "MP5A4"),
                    Shop = shop,
                    AppUser = user,
                    Name = "MP5A4",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "M92 Pistol"),
                    Shop = shop,
                    AppUser = user,
                    Name = "M92 Pistol",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Python Revolver"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Python Revolver",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Nailgun"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Nailgun",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Spas-12 Shotgun"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Spas-12 Shotgun",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "L96 Rifle"),
                    Shop = shop,
                    AppUser = user,
                    Name = "L96 Rifle",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Weapon"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "M39 Rifle"),
                    Shop = shop,
                    AppUser = user,
                    Name = "M39 Rifle",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Resources"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Charcoal"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Charcoal",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Resources"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Cloth"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Cloth",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Resources"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Explosives"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Explosives",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Resources"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Animal Fat"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Animal Fat",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Resources"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Gun Powder"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Gun Powder",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Resources"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "High Quality Metal Ore"),
                    Shop = shop,
                    AppUser = user,
                    Name = "High Quality Metal Ore",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Resources"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Leather"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Leather",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Resources"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Metal Fragments"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Metal Fragments",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Resources"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Metal Ore"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Metal Ore",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Resources"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "High Quality Metal"),
                    Shop = shop,
                    AppUser = user,
                    Name = "High Quality Metal",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Resources"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Sulfur"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Sulfur",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Resources"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Sulfur Ore"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Sulfur Ore",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Resources"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Wood"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Wood",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Ammunition"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Handmade Shell"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Handmade Shell",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Ammunition"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Pistol Bullet"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Pistol Bullet",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Ammunition"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Incendiary Pistol Bullet"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Incendiary Pistol Bullet",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Ammunition"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "HV Pistol Ammo"),
                    Shop = shop,
                    AppUser = user,
                    Name = "HV Pistol Ammo",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Ammunition"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "5.56 Rifle Ammo"),
                    Shop = shop,
                    AppUser = user,
                    Name = "5.56 Rifle Ammo",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Ammunition"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Explosive 5.56 Rifle Ammo"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Explosive 5.56 Rifle Ammo",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Ammunition"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "HV 5.56 Rifle Ammo"),
                    Shop = shop,
                    AppUser = user,
                    Name = "HV 5.56 Rifle Ammo",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Ammunition"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Incendiary 5.56 Rifle Ammo"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Incendiary 5.56 Rifle Ammo",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Ammunition"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Rocket"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Rocket",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Ammunition"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Incendiary Rocket"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Incendiary Rocket",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Ammunition"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "High Velocity Rocket"),
                    Shop = shop,
                    AppUser = user,
                    Name = "High Velocity Rocket",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Ammunition"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Smoke Rocket WIP!!!!"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Smoke Rocket WIP!!!!",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Ammunition"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "12 Gauge Buckshot"),
                    Shop = shop,
                    AppUser = user,
                    Name = "12 Gauge Buckshot",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Ammunition"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "12 Gauge Slug"),
                    Shop = shop,
                    AppUser = user,
                    Name = "12 Gauge Slug",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Ammunition"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "High Velocity Arrow"),
                    Shop = shop,
                    AppUser = user,
                    Name = "High Velocity Arrow",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Ammunition"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Wooden Arrow"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Wooden Arrow",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Ammunition"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Bone Arrow"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Bone Arrow",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Ammunition"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Fire Arrow"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Fire Arrow",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Ammunition"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "12 Gauge Incendiary Shell"),
                    Shop = shop,
                    AppUser = user,
                    Name = "12 Gauge Incendiary Shell",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Bucket Helmet"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Bucket Helmet",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Coffee Can Helmet"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Coffee Can Helmet",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Hoodie"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Hoodie",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Jacket"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Jacket",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Snow Jacket - Red"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Snow Jacket - Red",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Jack O Lantern Angry"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Jack O Lantern Angry",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Jack O Lantern Happy"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Jack O Lantern Happy",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Improvised Balaclava"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Improvised Balaclava",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Metal Facemask"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Metal Facemask",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Metal Chest Plate"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Metal Chest Plate",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Riot Helmet"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Riot Helmet",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Road Sign Jacket"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Road Sign Jacket",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Shorts"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Shorts",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Shirt"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Shirt",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Tank Top"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Tank Top",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Heavy Plate Helmet"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Heavy Plate Helmet",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Heavy Plate Jacket"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Heavy Plate Jacket",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Heavy Plate Pants"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Heavy Plate Pants",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Facial Hair Style 01"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Facial Hair Style 01",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Female Hairstyle 01"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Female Hairstyle 01",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Female Hairstyle 02"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Female Hairstyle 02",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Female Armpit Hair 01"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Female Armpit Hair 01",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Female Eyebrow 01"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Female Eyebrow 01",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Female Pubic Hair 01"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Female Pubic Hair 01",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Male Hairstyle 01"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Male Hairstyle 01",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Male Hairstyle 02"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Male Hairstyle 02",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Male Armpit Hair 01"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Male Armpit Hair 01",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Male Eyebrow 01"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Male Eyebrow 01",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Male Pubic Hair 01"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Male Pubic Hair 01",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Clothing"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Clatter Helmet"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Clatter Helmet",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Concrete Barricade"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Concrete Barricade",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Metal Barricade"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Metal Barricade",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Sandbag Barricade"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Sandbag Barricade",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Stone Barricade"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Stone Barricade",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Barbed Wooden Barricade"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Barbed Wooden Barricade",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Bed"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Bed",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Ceiling Light"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Ceiling Light",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Large Furnace"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Large Furnace",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "High External Stone Gate"),
                    Shop = shop,
                    AppUser = user,
                    Name = "High External Stone Gate",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "High External Wooden Gate"),
                    Shop = shop,
                    AppUser = user,
                    Name = "High External Wooden Gate",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Salvaged Shelves"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Salvaged Shelves",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Metal horizontal embrasure"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Metal horizontal embrasure",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Metal Vertical embrasure"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Metal Vertical embrasure",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Wood Shutters"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Wood Shutters",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Small Oil Refinery"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Small Oil Refinery",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "High External Wooden Wall"),
                    Shop = shop,
                    AppUser = user,
                    Name = "High External Wooden Wall",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "High External Stone Wall"),
                    Shop = shop,
                    AppUser = user,
                    Name = "High External Stone Wall",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Water Barrel"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Water Barrel",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Large Planter Box"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Large Planter Box",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Small Planter Box"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Small Planter Box",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Chair"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Chair",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Door Closer"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Door Closer",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Table"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Table",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Rug"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Rug",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Rug Bear Skin"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Rug Bear Skin",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Locker"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Locker",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Netting"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Netting",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Work Bench Level 1"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Work Bench Level 1",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Work Bench Level 2"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Work Bench Level 2",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Work Bench Level 3"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Work Bench Level 3",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Constructions"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Garage Door"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Garage Door",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Tools"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Salvaged Axe"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Salvaged Axe",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Tools"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Salvaged Hammer"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Salvaged Hammer",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Tools"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Hatchet"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Hatchet",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Tools"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Salvaged Icepick"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Salvaged Icepick",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Tools"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Pick Axe"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Pick Axe",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Tools"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Salvaged Cleaver"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Salvaged Cleaver",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Tools"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Salvaged Sword"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Salvaged Sword",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Tools"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Survey Charge"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Survey Charge",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Tools"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Water Bucket"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Water Bucket",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Tools"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Chainsaw"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Chainsaw",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Medicines"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Anti-Radiation Pills"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Anti-Radiation Pills",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Medicines"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Bandage"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Bandage",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Medicines"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Large Medkit"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Large Medkit",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Medicines"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Medical Syringe"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Medical Syringe",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Food"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Apple"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Apple",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Food"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Bear Meat Cooked"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Bear Meat Cooked",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Food"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Black Raspberries"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Black Raspberries",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Food"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Blueberries"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Blueberries",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Food"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Cooked Chicken"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Cooked Chicken",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Food"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Chocolate Bar"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Chocolate Bar",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Food"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Granola Bar"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Granola Bar",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Food"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Cooked Wolf Meat"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Cooked Wolf Meat",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Food"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Birthday Cake"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Birthday Cake",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Auto Turret"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Auto Turret",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Large Wood Box"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Large Wood Box",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "CCTV Camera"),
                    Shop = shop,
                    AppUser = user,
                    Name = "CCTV Camera",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Acoustic Guitar"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Acoustic Guitar",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Code Lock"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Code Lock",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Targeting Computer"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Targeting Computer",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Land Mine"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Land Mine",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "WeaponAttachment"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Weapon Flashlight"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Weapon Flashlight",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "WeaponAttachment"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Holosight"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Holosight",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "WeaponAttachment"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Weapon Lasersight"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Weapon Lasersight",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "WeaponAttachment"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Silencer"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Silencer",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "WeaponAttachment"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "8x Zoom Scope"),
                    Shop = shop,
                    AppUser = user,
                    Name = "8x Zoom Scope",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "WeaponAttachment"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Muzzle Brake"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Muzzle Brake",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "WeaponAttachment"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Muzzle Boost"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Muzzle Boost",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Flame Turret"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Flame Turret",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Tuna Can Lamp"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Tuna Can Lamp",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Vending Machine"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Vending Machine",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Metal Shop Front"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Metal Shop Front",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Fridge"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Fridge",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Spinning wheel"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Spinning wheel",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Binoculars"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Binoculars",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Simple Handmade Sight"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Simple Handmade Sight",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Search Light"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Search Light",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Scrap"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Scrap",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Mail Box"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Mail Box",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Water Jug"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Water Jug",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Drop Box"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Drop Box",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Shotgun Trap"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Shotgun Trap",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Glowing Eyes"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Glowing Eyes",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Scarecrow"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Scarecrow",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Skull Fire Pit"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Skull Fire Pit",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Barbeque"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Barbeque",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Other"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Flashlight"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Flashlight",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Electricity"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "RAND Switch"),
                    Shop = shop,
                    AppUser = user,
                    Name = "RAND Switch",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Electricity"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Large Rechargable Battery"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Large Rechargable Battery",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Electricity"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Small Rechargable Battery"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Small Rechargable Battery",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Electricity"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Blocker"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Blocker",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Electricity"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Cable Tunnel"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Cable Tunnel",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Electricity"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Counter"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Counter",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Electricity"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Door Controller"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Door Controller",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Electricity"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Small Generator"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Small Generator",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Electricity"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Laser Detector"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Laser Detector",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Electricity"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "OR Switch"),
                    Shop = shop,
                    AppUser = user,
                    Name = "OR Switch",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Electricity"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Pressure Pad"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Pressure Pad",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Electricity"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Simple Light"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Simple Light",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Electricity"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Large Solar Panel"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Large Solar Panel",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Electricity"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Splitter"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Splitter",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Electricity"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Switch"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Switch",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Electricity"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Timer"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Timer",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Electricity"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "XOR Switch"),
                    Shop = shop,
                    AppUser = user,
                    Name = "XOR Switch",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Electricity"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Electrical Branch"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Electrical Branch",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Electricity"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Root Combiner"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Root Combiner",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Electricity"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Memory Cell"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Memory Cell",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Electricity"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Party Hat"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Party Hat",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Electricity"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Wire Tool"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Wire Tool",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Components"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Bleach"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Bleach",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Components"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Duct Tape"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Duct Tape",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Components"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Gears"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Gears",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Components"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Glue"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Glue",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Components"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Metal Blade"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Metal Blade",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Components"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Metal Pipe"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Metal Pipe",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Components"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Metal Spring"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Metal Spring",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Components"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Empty Propane Tank"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Empty Propane Tank",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Components"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Rifle Body"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Rifle Body",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Components"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Road Signs"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Road Signs",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Components"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Rope"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Rope",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Components"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Sewing Kit"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Sewing Kit",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Components"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Sheet Metal"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Sheet Metal",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Components"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Sticks"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Sticks",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Components"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Tarp"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Tarp",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Components"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Tech Trash"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Tech Trash",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Holidays"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Reindeer Antlers"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Reindeer Antlers",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Holidays"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Candy Cane Club"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Candy Cane Club",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Holidays"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Stone Fireplace"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Stone Fireplace",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Holidays"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Snowman"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Snowman",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Holidays"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Christmas Lights"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Christmas Lights",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Holidays"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Christmas Tree"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Christmas Tree",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Holidays"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Festive Window Garland"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Festive Window Garland",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                },
                new RustProduct
                {
                    Id = Guid.NewGuid(),
                    RustCategory = userDefaultCategories.First(x => x.Name == "Holidays"),
                    RustItem = defaultRustItems.FirstOrDefault(x => x.Name == "Christmas Door Wreath"),
                    Shop = shop,
                    AppUser = user,
                    Name = "Christmas Door Wreath",
                    Price = 0,
                    Amount = 1,
                    Description = null,
                    Discount = 0,
                    BlockedTill = default
                }
            };

            return (userDefaultCategories, userItemsWeapons);
        }
    }
}

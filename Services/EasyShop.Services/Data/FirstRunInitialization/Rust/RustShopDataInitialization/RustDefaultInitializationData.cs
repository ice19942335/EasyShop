using System;
using System.Collections.Generic;
using EasyShop.Domain.Entries.Rust;

namespace EasyShop.Services.Data.FirstRunInitialization.Rust.RustShopDataInitialization
{
    public static class RustDefaultInitializationData
    {
        public static readonly List<RustServerMap> DefaultRustServerMaps = new List<RustServerMap>
        {
            new RustServerMap
            {
                Id = Guid.NewGuid(),
                Type = "Savas Island"
            },
            new RustServerMap
            {
                Id = Guid.NewGuid(),
                Type = "Hapis Island"
            },
            new RustServerMap
            {
                Id = Guid.NewGuid(),
                Type = "Environment"
            },
            new RustServerMap
            {
                Id = Guid.NewGuid(),
                Type = "Procedural Map"
            }
        };

        public static readonly List<RustCategory> DefaultRustCategories = new List<RustCategory>
        {
            new RustCategory
            {
                Id = Guid.NewGuid(),
                Index = 1,
                AppUser = null,
                Name = "Weapon"
            },
            new RustCategory
            {
                Id = Guid.NewGuid(),
                Index = 2,
                AppUser = null,
                Name = "Ammunition"
            },
            new RustCategory
            {
                Id = Guid.NewGuid(),
                Index = 3,
                AppUser = null,
                Name = "Weapon Attachment"
            },
            new RustCategory
            {
                Id = Guid.NewGuid(),
                Index = 4,
                AppUser = null,
                Name = "Clothing"
            },
            new RustCategory
            {
                Id = Guid.NewGuid(),
                Index = 5,
                AppUser = null,
                Name = "Medicines"
            },
            new RustCategory
            {
                Id = Guid.NewGuid(),
                Index = 6,
                AppUser = null,
                Name = "Food"
            },
            new RustCategory
            {
                Id = Guid.NewGuid(),
                Index = 7,
                AppUser = null,
                Name = "Resources"
            },
            new RustCategory
            {
                Id = Guid.NewGuid(),
                Index = 8,
                AppUser = null,
                Name = "Constructions"
            },
            new RustCategory
            {
                Id = Guid.NewGuid(),
                Index = 9,
                AppUser = null,
                Name = "Tools"
            },
            new RustCategory
            {
                Id = Guid.NewGuid(),
                Index = 10,
                AppUser = null,
                Name = "Electricity"
            },
            new RustCategory
            {
                Id = Guid.NewGuid(),
                Index = 11,
                AppUser = null,
                Name = "Components"
            },
            new RustCategory
            {
                Id = Guid.NewGuid(),
                Index = 12,
                AppUser = null,
                Name = "Holidays"
            },
            new RustCategory
            {
                Id = Guid.NewGuid(),
                Index = 13,
                AppUser = null,
                Name = "Other"
            }
        };

        public static readonly List<RustItemType> DefaultRustItemTypes = new List<RustItemType>
        {
            new RustItemType
            {
                Id = Guid.NewGuid(),
                TypeName = "Item"
            }
        };

        public static readonly List<RustItem> DefaultRustItems = new List<RustItem>
        {
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "bow.hunting",
                Name = "Hunting Bow",
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/wDVJwjk.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "crossbow",
                Name = "Crossbow",
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/ENN6ZSr.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "explosive.timed",
                Name = "Timed Explosive Charge",
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/Z8Lgb9g.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "grenade.beancan",
                Name = "Beancan Grenade",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/dL33uWG.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "grenade.f1",
                Name = "F1 Grenade",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/7Z2g3hU.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "lmg.m249",
                Name = "M249",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/Lgw8rjJ.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "longsword",
                Name = "Longsword",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/CPg5LMs.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "mace",
                Name = "Mace",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/AFmODGW.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "machete",
                Name = "Machete",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/QcwUWKg.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "pistol.semiauto",
                Name = "Semi-Automatic Pistol",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/Yc7mzkA.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "rifle.ak",
                Name = "Assault Rifle",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/7R9p8it.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "rifle.bolt",
                Name = "Bolt Action Rifle",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/iJ1olW4.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "rifle.semiauto",
                Name = "Semi-Automatic Rifle",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/cdZGI28.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "rocket.launcher",
                Name = "Rocket Launcher",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/JlhqjsT.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "shotgun.waterpipe",
                Name = "Waterpipe Shotgun",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/6NE4876.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "smg.2",
                Name = "Custom SMG",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/OcqzErL.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "smg.thompson",
                Name = "Thompson",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/XK4wa6f.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "flamethrower",
                Name = "Flame Thrower",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/GVMpJVo.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "rifle.lr300",
                Name = "LR-300 Assault Rifle",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/Wcquqyl.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "smg.mp5",
                Name = "MP5A4",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/fFq55Ut.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "pistol.m92",
                Name = "M92 Pistol",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/0IaUs9G.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "pistol.python",
                Name = "Python Revolver",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/ZaaIQSo.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "pistol.nailgun",
                Name = "Nailgun",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/BOxlxmV.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "shotgun.spas12",
                Name = "Spas-12 Shotgun",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/HhkJBcc.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "rifle.l96",
                Name = "L96 Rifle",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/CSJFBrh.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "rifle.m39",
                Name = "M39 Rifle",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/qqcwBlN.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "charcoal",
                Name = "Charcoal",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/ezHb5GY.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "cloth",
                Name = "Cloth",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/gQM6iDH.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "explosives",
                Name = "Explosives",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/tNfWhQu.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "fat.animal",
                Name = "Animal Fat",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/hZbNTtx.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "gunpowder",
                Name = "Gun Powder",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/OTzldM8.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "hq.metal.ore",
                Name = "High Quality Metal Ore",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/nWug93B.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "leather",
                Name = "Leather",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/vR7mc9I.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "metal.fragments",
                Name = "Metal Fragments",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/YpbfyTi.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "metal.ore",
                Name = "Metal Ore",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/WCmU15A.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "metal.refined",
                Name = "High Quality Metal",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/q9obSjv.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "sulfur",
                Name = "Sulfur",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/EGhYNWF.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "sulfur.ore",
                Name = "Sulfur Ore",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/RF5W9sH.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "wood",
                Name = "Wood",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/YTHnJ9o.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.handmade.shell",
                Name = "Handmade Shell",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/Cg2kt7m.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.rifle",
                Name = "5.56 Rifle Ammo",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/7IQ5OlV.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.rifle.explosive",
                Name = "Explosive 5.56 Rifle Ammo",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/jWhbVg6.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.rifle.hv",
                Name = "HV 5.56 Rifle Ammo",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/FXXpCbn.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.rifle.incendiary",
                Name = "Incendiary 5.56 Rifle Ammo",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/mxhSLau.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.rocket.basic",
                Name = "Rocket",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/AdRUvnJ.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.rocket.fire",
                Name = "Incendiary Rocket",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/SQ7L2wS.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.rocket.hv",
                Name = "High Velocity Rocket",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/4SumHsj.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.pistol",
                Name = "Pistol Bullet",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/NSKUNdq.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.pistol.fire",
                Name = "Incendiary Pistol Bullet",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/yeutDV9.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.pistol.hv",
                Name = "HV Pistol Ammo",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/tfU5zAo.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.rocket.smoke",
                Name = "Smoke Rocket WIP!!!!",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/f5UHMxC.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.shotgun",
                Name = "12 Gauge Buckshot",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/YvGDUNv.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.shotgun.slug",
                Name = "12 Gauge Slug",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/PVkPXLB.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.shotgun.fire",
                Name = "12 Gauge Incendiary Shell",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/VOxwxBf.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "arrow.hv",
                Name = "High Velocity Arrow",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/HIsAGnl.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "arrow.wooden",
                Name = "Wooden Arrow",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/NwjfGxI.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "arrow.bone",
                Name = "Bone Arrow",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/fO0WJtj.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "arrow.fire",
                Name = "Fire Arrow",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/WGly3Lf.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "bucket.helmet",
                Name = "Bucket Helmet",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/EsMBuXz.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "coffeecan.helmet",
                Name = "Coffee Can Helmet",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/Y9kOnhi.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "hoodie",
                Name = "Hoodie",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/3tOKoAA.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "jacket",
                Name = "Jacket",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/rm1twCW.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "jacket.snow",
                Name = "Snow Jacket - Red",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/6ETbDNF.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "jackolantern.angry",
                Name = "Jack O Lantern Angry",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/u4GlUKC.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "jackolantern.happy",
                Name = "Jack O Lantern Happy",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/Fetgu7t.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "mask.balaclava",
                Name = "Improvised Balaclava",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/ICXoLJb.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "metal.facemask",
                Name = "Metal Facemask",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/qa7HjDB.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "metal.plate.torso",
                Name = "Metal Chest Plate",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/qkcdbEI.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "riot.helmet",
                Name = "Riot Helmet",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/uwfWNsN.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "roadsign.jacket",
                Name = "Road Sign Jacket",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/cC4WsjK.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "pants.shorts",
                Name = "Shorts",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/Z4HIhnp.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "shirt.collared",
                Name = "Shirt",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/28zkqij.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "shirt.tanktop",
                Name = "Tank Top",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/hrKfQAS.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "heavy.plate.helmet",
                Name = "Heavy Plate Helmet",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/EAfJK1X.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "heavy.plate.jacket",
                Name = "Heavy Plate Jacket",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/BVU0dXs.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "heavy.plate.pants",
                Name = "Heavy Plate Pants",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/tYeiTNv.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "facialhair.style01",
                Name = "Facial Hair Style 01",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/dHBPrDJ.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "female_hairstyle_01",
                Name = "Female Hairstyle 01",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/773fnD0.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "female_hairstyle_02",
                Name = "Female Hairstyle 02",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/O6e4Yi8.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "femalearmpithair.style01",
                Name = "Female Armpit Hair 01",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/eUMtsfq.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "femaleeyebrow.style01",
                Name = "Female Eyebrow 01",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/UfWPSFa.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "femalepubichair.style01",
                Name = "Female Pubic Hair 01",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/KgOLWgB.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "male_hairstyle_01",
                Name = "Male Hairstyle 01",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/DeU5STX.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "male_hairstyle_02",
                Name = "Male Hairstyle 02",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/XeFUnre.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "malearmpithair.style01",
                Name = "Male Armpit Hair 01",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/onpUucT.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "maleeyebrow.style01",
                Name = "Male Eyebrow 01",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/IvijVaz.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "malepubichair.style01",
                Name = "Male Pubic Hair 01",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/pEVRhwP.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "clatter.helmet",
                Name = "Clatter Helmet",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/wUvswlS.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "barricade.concrete",
                Name = "Concrete Barricade",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/h71XM4y.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "barricade.metal",
                Name = "Metal Barricade",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/C79hgiu.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "barricade.sandbags",
                Name = "Sandbag Barricade",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/LFpmcwV.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "barricade.stone",
                Name = "Stone Barricade",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/pyN8xfa.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "barricade.woodwire",
                Name = "Barbed Wooden Barricade",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/FlfLigQ.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "bed",
                Name = "Bed",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/hkwEFcu.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ceilinglight",
                Name = "Ceiling Light",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/Ldon7vR.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "furnace.large",
                Name = "Large Furnace",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/dxvjCCE.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "gates.external.high.stone",
                Name = "High External Stone Gate",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/7EzOpqb.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "	gates.external.high.wood",
                Name = "High External Wooden Gate",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/rk9mkqY.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "shelves",
                Name = "Salvaged Shelves",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/fYizHlT.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "shutter.metal.embrasure.a",
                Name = "Metal horizontal embrasure",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/lw6tfoD.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "shutter.metal.embrasure.b",
                Name = "Metal Vertical embrasure",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/nHytRvi.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "shutter.wood.a",
                Name = "Wood Shutters",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/8l5eig1.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "wall.external.high",
                Name = "High External Wooden Wall",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/zLJGvzz.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "wall.external.high.stone",
                Name = "High External Stone Wall",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/TxiK4Og.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "water.barrel",
                Name = "Water Barrel",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/J97Zym5.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "planter.large",
                Name = "Large Planter Box",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/m2hLjyN.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "planter.small",
                Name = "Small Planter Box",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/qjJPpLE.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "chair",
                Name = "Chair",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/WMdsvoG.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "door.closer",
                Name = "Door Closer",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/It5uFMy.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "small.oil.refinery",
                Name = "Small Oil Refinery",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/kFWxy4k.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "table",
                Name = "Table",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/aMJQ5M1.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "rug",
                Name = "Rug",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/7Kr1GP4.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "rug.bear",
                Name = "Rug Bear Skin",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/Itmrq9B.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "locker",
                Name = "Locker",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/f7Id9tm.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "wall.frame.netting",
                Name = "Netting",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/J4ZNG0v.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "workbench1",
                Name = "Work Bench Level 1",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/HtkhPMp.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "workbench2",
                Name = "Work Bench Level 2",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/1LKSaUf.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "workbench3",
                Name = "Work Bench Level 3",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/AZounls.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "wall.frame.garagedoor",
                Name = "Garage Door",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/T9Snlc4.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "axe.salvaged",
                Name = "Salvaged Axe",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/VlXHPk1.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "hammer.salvaged",
                Name = "Salvaged Hammer",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/cJZZkbI.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "hatchet",
                Name = "Hatchet",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/ae2tEnj.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "icepick.salvaged",
                Name = "Salvaged Icepick",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/zUjZ7Ib.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "pickaxe",
                Name = "Pick Axe",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/BBKxshq.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "salvaged.cleaver",
                Name = "Salvaged Cleaver",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/sfR5lcI.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "salvaged.sword",
                Name = "Salvaged Sword",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/n9IY5wI.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "surveycharge",
                Name = "Survey Charge",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/HnkB1yd.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "bucket.water",
                Name = "Water Bucket",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/Hxb8hws.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "chainsaw",
                Name = "Chainsaw",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/rkrAKOJ.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "antiradpills",
                Name = "Anti-Radiation Pills",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/grnvcds.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "bandage",
                Name = "Bandage",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/LQmcjqQ.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "largemedkit",
                Name = "Large Medkit",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/IlihoWX.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "	syringe.medical",
                Name = "Medical Syringe",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/06UtuMW.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "apple",
                Name = "Apple",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/2E1m2IQ.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "bearmeat.cooked",
                Name = "Bear Meat Cooked",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/aSVnAve.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "black.raspberries",
                Name = "Black Raspberries",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/5IvfXnr.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "blueberries",
                Name = "Blueberries",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/s4BCWrU.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "chicken.cooked",
                Name = "Cooked Chicken",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/3IBKQ8k.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "chocholate",
                Name = "Chocolate Bar",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/siqkcPc.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "granolabar",
                Name = "Granola Bar",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/uhD1vEC.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "wolfmeat.cooked",
                Name = "Cooked Wolf Meat",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/wsJS0E8.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "cakefiveyear",
                Name = "Birthday Cake",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/OAk74qk.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "autoturret",
                Name = "Auto Turret",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/FMO5lmV.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "box.wooden.large",
                Name = "Large Wood Box",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/UGi91so.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "cctv.camera",
                Name = "CCTV Camera",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/GA7zSFe.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "fun.guitar",
                Name = "Acoustic Guitar",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/EWr3yiU.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "lock.code",
                Name = "Code Lock",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/KPl7qQT.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "targeting.computer",
                Name = "Targeting Computer",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/sHrCgdx.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "trap.landmine",
                Name = "Land Mine",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/pFIczBX.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "weapon.mod.flashlight",
                Name = "Weapon Flashlight",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/GI4USHF.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "weapon.mod.holosight",
                Name = "Holosight",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/iOLujLI.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "weapon.mod.lasersight",
                Name = "Weapon Lasersight",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/E4PADT6.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "weapon.mod.silencer",
                Name = "Silencer",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/DnQwe0C.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "weapon.mod.8x.scope",
                Name = "8x Zoom Scope",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/fcQGxsk.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "weapon.mod.muzzlebrake",
                Name = "Muzzle Brake",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/pamATqQ.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "weapon.mod.muzzleboost",
                Name = "Muzzle Boost",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/u7fEpIB.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "flameturret",
                Name = "Flame Turret",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/Y8cgBHI.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "tunalight",
                Name = "Tuna Can Lamp",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/icWNKPM.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "vending.machine",
                Name = "Vending Machine",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/kopbURV.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "wall.frame.shopfront.metal",
                Name = "Metal Shop Front",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/kXutRKx.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "fridge",
                Name = "Fridge",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/aic8awn.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "spinner.wheel",
                Name = "Spinning wheel",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/4iA3Qsb.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "tool.binoculars",
                Name = "Binoculars",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/2QR1OAG.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "weapon.mod.simplesight",
                Name = "Simple Handmade Sight",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/cDmIqnI.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "searchlight",
                Name = "Search Light",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/KPHIwh1.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "scrap",
                Name = "Scrap",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/RzhNHKl.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "mailbox",
                Name = "Mail Box",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/6XrfxLq.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "waterjug",
                Name = "Water Jug",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/jWr2Xw9.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "dropbox",
                Name = "Drop Box",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/yHREy7p.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "guntrap",
                Name = "Shotgun Trap",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/2BaE5eH.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "gloweyes",
                Name = "Glowing Eyes",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/KN5Rfxe.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "scarecrow",
                Name = "Scarecrow",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/GSOLmrE.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "skull_fire_pit",
                Name = "Skull Fire Pit",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/Ebkgb8j.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "bbq",
                Name = "Barbeque",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/4UPcPeW.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "flashlight.held",
                Name = "Flashlight",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/OdEfQom.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.random.switch",
                Name = "RAND Switch",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/OsZXKh6.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.battery.rechargable.large",
                Name = "Large Rechargable Battery",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/3RMaulO.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.battery.rechargable.small",
                Name = "Small Rechargable Battery",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/3c9S8An.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.blocker",
                Name = "Blocker",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/s1i6xAX.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.cabletunnel",
                Name = "Cable Tunnel",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/OdEfQom.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.counter",
                Name = "Counter",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/56JLu4E.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.doorcontroller",
                Name = "Door Controller",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/7EhJFZ4.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.fuelgenerator.small",
                Name = "Small Generator",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/K1EI8Uh.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.laserdetector",
                Name = "Laser Detector",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/ulKhdNT.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.orswitch",
                Name = "OR Switch",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/Ei83iGN.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.pressurepad",
                Name = "Pressure Pad",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/tkL9Wlq.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.simplelight",
                Name = "Simple Light",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/6XrfxLq.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.solarpanel.large",
                Name = "Large Solar Panel",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/vkBOsqV.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.splitter",
                Name = "Splitter",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/agWhtmE.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.switch",
                Name = "Switch",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/HZkkwS3.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.timer",
                Name = "Timer",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/cJChFu6.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.xorswitch",
                Name = "XOR Switch",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/Yu14qFp.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electrical.branch",
                Name = "Electrical Branch",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/1Ck4QfF.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electrical.combiner",
                Name = "Root Combiner",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/8IaV6Gb.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electrical.memorycell",
                Name = "Memory Cell",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/Ys5mjfx.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "partyhat",
                Name = "Party Hat",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/6WiXF5a.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "wiretool",
                Name = "Wire Tool",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/0s27Iwi.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "bleach",
                Name = "Bleach",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/XDBf5Fv.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ducttape",
                Name = "Duct Tape",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/gCiL02t.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "gears",
                Name = "Gears",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/04PyYLx.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "glue",
                Name = "Glue",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/af2fzm6.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "metalblade",
                Name = "Metal Blade",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/EAvS7pD.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "metalpipe",
                Name = "Metal Pipe",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/odC3s3l.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "metalspring",
                Name = "Metal Spring",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/JSn76l6.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "propanetank",
                Name = "Empty Propane Tank",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/rUbCXXn.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "riflebody",
                Name = "Rifle Body",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/rRPBZvb.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "roadsigns",
                Name = "Road Signs",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/xaCYQwv.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "rope",
                Name = "Rope",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/bEYxVwK.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "sewingkit",
                Name = "Sewing Kit",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/nlwCkOX.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "sheetmetal",
                Name = "Sheet Metal",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/HmEx41q.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "sticks",
                Name = "Sticks",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/T8qZIYj.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "tarp",
                Name = "Tarp",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/4ubLOIC.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "techparts",
                Name = "Tech Trash",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/KHIVDOq.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "attire.reindeer.headband",
                Name = "Reindeer Antlers",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/dVoScfs.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "candycaneclub",
                Name = "Candy Cane Club",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/ogfMUnr.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "fireplace.stone",
                Name = "Stone Fireplace",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/qR5MXuv.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "snowman",
                Name = "Snowman",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/7yE4mnB.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "xmas.lightstring",
                Name = "Christmas Lights",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/p9KeVYk.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "xmas.tree",
                Name = "Christmas Tree",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/vRx8V0t.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "xmas.window.garland",
                Name = "Festive Window Garland",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/iwWTQhs.png"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "xmasdoorwreath",
                Name = "Christmas Door Wreath",


                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "https://i.imgur.com/PCsp10M.png"
            }
        };
    }
}

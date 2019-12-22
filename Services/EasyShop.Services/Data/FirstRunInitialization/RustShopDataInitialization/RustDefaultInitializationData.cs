using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Entries.Items.RustItems;

namespace EasyShop.Services.Data.FirstRunInitialization.RustShopDataInitialization
{
    public static class RustDefaultInitializationData
    {
        public static readonly List<RustCategory> DefaultRustCategories = new List<RustCategory>
        {
            new RustCategory
            {
                Id = Guid.NewGuid(),
                AppUser = null,
                Name = "Weapon"
            },
            new RustCategory
            {
                Id = Guid.NewGuid(),
                AppUser = null,
                Name = "Resources"
            },
            new RustCategory
            {
                Id = Guid.NewGuid(),
                AppUser = null,
                Name = "Ammunition"
            },
            new RustCategory
            {
                Id = Guid.NewGuid(),
                AppUser = null,
                Name = "Clothing"
            },
            new RustCategory
            {
                Id = Guid.NewGuid(),
                AppUser = null,
                Name = "Constructions"
            },
            new RustCategory
            {
                Id = Guid.NewGuid(),
                AppUser = null,
                Name = "Tools"
            },
            new RustCategory
            {
                Id = Guid.NewGuid(),
                AppUser = null,
                Name = "Medicines"
            },
            new RustCategory
            {
                Id = Guid.NewGuid(),
                AppUser = null,
                Name = "Food"
            },
            new RustCategory
            {
                Id = Guid.NewGuid(),
                AppUser = null,
                Name = "Electricity"
            },
            new RustCategory
            {
                Id = Guid.NewGuid(),
                AppUser = null,
                Name = "Components"
            },
            new RustCategory
            {
                Id = Guid.NewGuid(),
                AppUser = null,
                Name = "Holidays"
            },
            new RustCategory
            {
                Id = Guid.NewGuid(),
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
                RustId = "bow.hunting",
                Name = "Hunting Bow",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-853695669"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "crossbow",
                Name = "Crossbow",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "2123300234"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "explosive.timed",
                Name = "Timed Explosive Charge",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "498591726"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "grenade.beancan",
                Name = "Beancan Grenade",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "384204160"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "grenade.f1",
                Name = "F1 Grenade",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1308622549"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "lmg.m249",
                Name = "M249",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "193190034"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "longsword",
                Name = "Longsword",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "146685185"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "mace",
                Name = "Mace",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "3343606"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "machete",
                Name = "Machete",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "825308669"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "pistol.semiauto",
                Name = "Semi-Automatic Pistol",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "548699316"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "rifle.ak",
                Name = "Assault Rifle",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1461508848"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "rifle.bolt",
                Name = "Bolt Action Rifle",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-55660037"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "rifle.semiauto",
                Name = "Semi-Automatic Rifle",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1745053053"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "rocket.launcher",
                Name = "Rocket Launcher",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "649603450"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "shotgun.waterpipe",
                Name = "Waterpipe Shotgun",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "2077983581"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "smg.2",
                Name = "Custom SMG",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "109552593"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "smg.thompson",
                Name = "Thompson",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "456448245"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "flamethrower",
                Name = "Flame Thrower",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1045869440"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "rifle.lr300",
                Name = "LR-300 Assault Rifle",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1716193401"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "smg.mp5",
                Name = "MP5A4",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-2094080303"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "pistol.m92",
                Name = "M92 Pistol",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "371156815"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "pistol.python",
                Name = "Python Revolver",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "2033918259"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "pistol.nailgun",
                Name = "Nailgun",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "449769971"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "shotgun.spas12",
                Name = "Spas-12 Shotgun",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "621575320"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "rifle.l96",
                Name = "L96 Rifle",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-778367295"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "rifle.m39",
                Name = "M39 Rifle",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "28201841"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "charcoal",
                Name = "Charcoal",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1436001773"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "cloth",
                Name = "Cloth",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "94756378"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "explosives",
                Name = "Explosives",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1755466030"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "fat.animal",
                Name = "Animal Fat",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1034048911"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "gunpowder",
                Name = "Gun Powder",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1580059655"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "hq.metal.ore",
                Name = "High Quality Metal Ore",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "2133577942"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "leather",
                Name = "Leather",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "50834473"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "metal.fragments",
                Name = "Metal Fragments",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "688032252"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "metal.ore",
                Name = "Metal Ore",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1059362949"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "metal.refined",
                Name = "High Quality Metal",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "374890416"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "sulfur",
                Name = "Sulfur",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-891243783"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "sulfur.ore",
                Name = "Sulfur Ore",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "889398893"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "wood",
                Name = "Wood",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "3655341"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "ammo.handmade.shell",
                Name = "Handmade Shell",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "2115555558"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "ammo.rifle",
                Name = "5.56 Rifle Ammo",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "815896488"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "ammo.rifle.explosive",
                Name = "Explosive 5.56 Rifle Ammo",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "805088543"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "ammo.rifle.hv",
                Name = "HV 5.56 Rifle Ammo",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1152393492"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "ammo.rifle.incendiary",
                Name = "Incendiary 5.56 Rifle Ammo",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "449771810"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "ammo.rocket.basic",
                Name = "Rocket",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1578894260"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "ammo.rocket.fire",
                Name = "Incendiary Rocket",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1436532208"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "ammo.rocket.hv",
                Name = "High Velocity Rocket",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "542276424"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "ammo.pistol",
                Name = "Pistol Bullet",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-533875561"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "ammo.pistol.fire",
                Name = "Incendiary Pistol Bullet",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1621541165"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "ammo.pistol.hv",
                Name = "HV Pistol Ammo",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-422893115"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "ammo.rocket.smoke",
                Name = "Smoke Rocket WIP!!!!",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1594947829"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "ammo.shotgun",
                Name = "12 Gauge Buckshot",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1035059994"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "ammo.shotgun.slug",
                Name = "12 Gauge Slug",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1819281075"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "ammo.shotgun.fire",
                Name = "12 Gauge Incendiary Shell",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1818890814"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "arrow.hv",
                Name = "High Velocity Arrow",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1280058093"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "arrow.wooden",
                Name = "Wooden Arrow",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-420273765"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "arrow.bone",
                Name = "Bone Arrow",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1775362679"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "arrow.fire",
                Name = "Fire Arrow",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1775249157"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "bucket.helmet",
                Name = "Bucket Helmet",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1260209393"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "coffeecan.helmet",
                Name = "Coffee Can Helmet",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-2128719593"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "hoodie",
                Name = "Hoodie",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1211618504"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "jacket",
                Name = "Jacket",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1167640370"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "jacket.snow",
                Name = "Snow Jacket - Red",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1616887133"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "jackolantern.angry",
                Name = "Jack O Lantern Angry",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1284735799"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "jackolantern.happy",
                Name = "Jack O Lantern Happy",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1278649848"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "mask.balaclava",
                Name = "Improvised Balaclava",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "997973965"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "metal.facemask",
                Name = "Metal Facemask",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-46848560"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "metal.plate.torso",
                Name = "Metal Chest Plate",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1265861812"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "riot.helmet",
                Name = "Riot Helmet",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "340009023"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "roadsign.jacket",
                Name = "Road Sign Jacket",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-288010497"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "pants.shorts",
                Name = "Shorts",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-459156023"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "shirt.collared",
                Name = "Shirt",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "24576628"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "shirt.tanktop",
                Name = "Tank Top",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1659202509"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "heavy.plate.helmet",
                Name = "Heavy Plate Helmet",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1351172108"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "heavy.plate.jacket",
                Name = "Heavy Plate JacketTest",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1404466285"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "heavy.plate.pants",
                Name = "Heavy Plate Pants",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1334615971"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "facialhair.style01",
                Name = "Male Facial Hair Style 01",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "726730162"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "female_hairstyle_01",
                Name = "Female Hairstyle 01",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "305916740"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "female_hairstyle_02",
                Name = "Female Hairstyle 02",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "305916741"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "femalearmpithair.style01",
                Name = "Female Armpit Hair 01",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "252529905"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "femaleeyebrow.style01",
                Name = "Female Eyebrow 01",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "471582113"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "femalepubichair.style01",
                Name = "Female Pubic Hair 01",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1138648591"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "male_hairstyle_01",
                Name = "Male Hairstyle 01",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1832205789"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "male_hairstyle_02",
                Name = "Male Hairstyle 02",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1832205788"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "malearmpithair.style01",
                Name = "Male Armpit Hair 01",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1625090418"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "maleeyebrow.style01",
                Name = "Male Eyebrow 01",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1269800768"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "malepubichair.style01",
                Name = "Male Pubic Hair 01",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "429648208"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "clatter.helmet",
                Name = "Clatter Helmet",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "968019378"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "barricade.concrete",
                Name = "Concrete Barricade",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "498312426"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "barricade.metal",
                Name = "Metal Barricade",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "504904386"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "barricade.sandbags",
                Name = "Sandbag Barricade",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1221200300"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "barricade.stone",
                Name = "Stone Barricade",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "510887968"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "barricade.woodwire",
                Name = "Barbed Wooden Barricade",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1024486167"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "bed",
                Name = "Bed",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "97409"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "ceilinglight",
                Name = "Ceiling Light",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-2095387015"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "furnace.large",
                Name = "Large Furnace",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1598149413"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "gates.external.high.stone",
                Name = "High External Stone Gate",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1779401418"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "	gates.external.high.wood",
                Name = "High External Wooden Gate",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-57285700"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "shelves",
                Name = "Salvaged Shelves",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "2057749608"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "shutter.metal.embrasure.a",
                Name = "Metal horizontal embrasure",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-529054135"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "shutter.metal.embrasure.b",
                Name = "Metal Vertical embrasure",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-529054134"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "shutter.wood.a",
                Name = "Wood Shutters",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "486166145"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "wall.external.high",
                Name = "High External Wooden Wall",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1792066367"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "wall.external.high.stone",
                Name = "High External Stone Wall",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-496055048"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "water.barrel",
                Name = "Water Barrel",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1628526499"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "planter.large",
                Name = "Large Planter Box",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "142147109"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "planter.small",
                Name = "Small Planter Box",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "148953073"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "chair",
                Name = "Chair",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "94623429"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "door.closer",
                Name = "Door Closer",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-778796102"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "small.oil.refinery",
                Name = "Small Oil Refinery",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "470729623"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "table",
                Name = "Table",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "110115790"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "rug",
                Name = "Rug",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "113284"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "rug.bear",
                Name = "Rug Bear Skin",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "569935070"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "locker",
                Name = "Locker",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1097452776"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "wall.frame.netting",
                Name = "Netting",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "313836902"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "workbench1",
                Name = "Work Bench Level 1",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-481416622"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "workbench2",
                Name = "Work Bench Level 2",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-481416621"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "workbench3",
                Name = "Work Bench Level 3",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-481416620"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "wall.frame.garagedoor",
                Name = "Garage Door",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "447918618"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "axe.salvaged",
                Name = "Salvaged Axe",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "790921853"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "hammer.salvaged",
                Name = "Salvaged Hammer",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1976561211"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "hatchet",
                Name = "Hatchet",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "698310895"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "icepick.salvaged",
                Name = "Salvaged Icepick",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1440143841"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "pickaxe",
                Name = "Pick Axe",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-578028723"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "salvaged.cleaver",
                Name = "Salvaged Cleaver",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1775234707"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "salvaged.sword",
                Name = "Salvaged Sword",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-388967316"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "surveycharge",
                Name = "Survey Charge",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1293049486"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "bucket.water",
                Name = "Water Bucket",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1192532973"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "chainsaw",
                Name = "Chainsaw",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1428021640"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "antiradpills",
                Name = "Anti-Radiation Pills",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1685058759"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "bandage",
                Name = "Bandage",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-337261910"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "largemedkit",
                Name = "Large Medkit",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-789202811"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "	syringe.medical",
                Name = "Medical Syringe",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "586484018"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "apple",
                Name = "Apple",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "93029210"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "bearmeat.cooked",
                Name = "Cooked Bear Meat",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-2043730634"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "black.raspberries",
                Name = "Black Raspberries",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1611480185"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "blueberries",
                Name = "Blueberries",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1063412582"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "chicken.cooked",
                Name = "Cooked Chicken",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1734319168"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "chocholate",
                Name = "Chocolate Bar",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-341443994"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "granolabar",
                Name = "Granola Bar",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "718197703"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "wolfmeat.cooked",
                Name = "Cooked Wolf Meat",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1691991080"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "cakefiveyear",
                Name = "Birthday Cake",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1973165031"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "autoturret",
                Name = "Auto Turret",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "563023711"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "box.wooden.large",
                Name = "Large Wood Box",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "271534758"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "cctv.camera",
                Name = "CCTV Camera",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1300054961"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "fun.guitar",
                Name = "Acoustic Guitar",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-217113639"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "lock.code",
                Name = "Code Lock",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-975723312"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "targeting.computer",
                Name = "Targeting Computer",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1490499512"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "trap.landmine",
                Name = "Land Mine",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "255101535"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "weapon.mod.flashlight",
                Name = "Weapon Flashlight",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1229879204"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "weapon.mod.holosight",
                Name = "Holosight",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-465236267"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "weapon.mod.lasersight",
                Name = "Weapon Lasersight",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "516382256"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "weapon.mod.silencer",
                Name = "Silencer",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1213686767"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "weapon.mod.8x.scope",
                Name = "8x Zoom Scope",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-141135377"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "weapon.mod.muzzlebrake",
                Name = "Muzzle Brake",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1569280852"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "weapon.mod.muzzleboost",
                Name = "Muzzle Boost",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1569356508"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "flameturret",
                Name = "Flame Turret",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1985408483"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "tunalight",
                Name = "Tuna Can Lamp",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "260214178"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "vending.machine",
                Name = "Vending Machine",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1847536522"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "wall.frame.shopfront.metal",
                Name = "Metal Shop Front",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "525244071"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "Fridge",
                Name = "fridge",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1266285051"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "spinner.wheel",
                Name = "Spinning wheel",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "552706886"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "tool.binoculars",
                Name = "Binoculars",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1480119738"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "weapon.mod.simplesight",
                Name = "Simple Handmade Sight",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "386382445"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "searchlight",
                Name = "Search Light",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-527558546"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "scrap",
                Name = "Scrap",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "109266897"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "mailbox",
                Name = "Mail Box",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "830965940"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "waterjug",
                Name = "Water Jug",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "547302405"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "dropbox",
                Name = "Drop Box",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1925723260"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "guntrap",
                Name = "Shotgun Trap",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "378365037"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "gloweyes",
                Name = "Glowing Eyes",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-522149009"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "scarecrow",
                Name = "Scarecrow",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1705696613"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "skull_fire_pit",
                Name = "Skull Fire Pit",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1859976884"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "bbq",
                Name = "Barbeque",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "97329"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "flashlight.held",
                Name = "Flashlight",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1496470781"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "electric.random.switch",
                Name = "RAND Switch",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1171735914"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "electric.battery.rechargable.large",
                Name = "Large Rechargable Battery",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "553270375"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "electric.battery.rechargable.small",
                Name = "Small Rechargable Battery",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-692338819"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "electric.blocker",
                Name = "Blocker",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-690968985"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "electric.cabletunnel",
                Name = "Cable Tunnel",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1835946060"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "electric.counter",
                Name = "Counter",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-216999575"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "electric.doorcontroller",
                Name = "Door Controller",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-502177121"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "electric.fuelgenerator.small",
                Name = "Small Generator",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-295829489"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "electric.laserdetector",
                Name = "Laser Detector",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-798293154"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "electric.orswitch",
                Name = "OR Switch",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1286302544"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "electric.pressurepad",
                Name = "Pressure Pad",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-2049214035"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "electric.simplelight",
                Name = "Simple Light",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-282113991"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "electric.solarpanel.large",
                Name = "Large Solar Panel",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "2090395347"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "electric.splitter",
                Name = "Splitter",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-563624462"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "electric.switch",
                Name = "Switch",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1951603367"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "electric.timer",
                Name = "Timer",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "665332906"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "electric.xorswitch",
                Name = "XOR Switch",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1293102274"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "electrical.branch",
                Name = "Electrical Branch",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1448252298"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "electrical.combiner",
                Name = "Root Combiner",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-458565393"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "electrical.memorycell",
                Name = "Memory Cell",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-746647361"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "partyhat",
                Name = "Party Hat",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-575744869"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "wiretool",
                Name = "Wire Tool",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-144417939"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "bleach",
                Name = "Bleach",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1386464949"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "ducttape",
                Name = "Duct Tape",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1891056868"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "gears",
                Name = "Gears",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "98228420"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "glue",
                Name = "Glue",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "3175989"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "metalblade",
                Name = "Metal Blade",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1567404401"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "metalpipe",
                Name = "Metal Pipe",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1057402571"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "metalspring",
                Name = "Metal Spring",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1835797460"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "propanetank",
                Name = "Empty Propane Tank",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1974032895"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "riflebody",
                Name = "Rifle Body",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1939428458"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "roadsigns",
                Name = "Road Signs",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-847065290"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "rope",
                Name = "Rope",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "3506418"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "sewingkit",
                Name = "Sewing Kit",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-419069863"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "sheetmetal",
                Name = "Sheet Metal",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1617374968"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "sticks",
                Name = "Sticks",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-892259869"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "tarp",
                Name = "Tarp",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "3552619"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "techparts",
                Name = "Tech Trash",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1471284746"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "attire.reindeer.headband",
                Name = "Reindeer Antlers",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-966287254"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "candycaneclub",
                Name = "Candy Cane Club",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1693683664"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "fireplace.stone",
                Name = "Stone Fireplace",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1908328648"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "snowman",
                Name = "Snowman",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-2055888649"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "xmas.lightstring",
                Name = "Christmas Lights",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1151126752"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "xmas.tree",
                Name = "Christmas Tree",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1926458555"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "xmas.window.garland",
                Name = "Festive Window Garland",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-460592212"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustId = "xmasdoorwreath",
                Name = "Christmas Door Wreath",
                Price = 0.10m,
                Amount = 1,
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1540879296"
            }
        };
    }
}

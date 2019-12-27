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
                ImgUrl = "-853695669"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "crossbow",
                Name = "Crossbow",
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "2123300234"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "explosive.timed",
                Name = "Timed Explosive Charge",
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "498591726"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "grenade.beancan",
                Name = "Beancan Grenade",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "384204160"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "grenade.f1",
                Name = "F1 Grenade",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1308622549"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "lmg.m249",
                Name = "M249",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "193190034"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "longsword",
                Name = "Longsword",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "146685185"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "mace",
                Name = "Mace",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "3343606"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "machete",
                Name = "Machete",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "825308669"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "pistol.semiauto",
                Name = "Semi-Automatic Pistol",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "548699316"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "rifle.ak",
                Name = "Assault Rifle",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1461508848"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "rifle.bolt",
                Name = "Bolt Action Rifle",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-55660037"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "rifle.semiauto",
                Name = "Semi-Automatic Rifle",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1745053053"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "rocket.launcher",
                Name = "Rocket Launcher",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "649603450"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "shotgun.waterpipe",
                Name = "Waterpipe Shotgun",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "2077983581"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "smg.2",
                Name = "Custom SMG",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "109552593"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "smg.thompson",
                Name = "Thompson",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "456448245"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "flamethrower",
                Name = "Flame Thrower",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1045869440"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "rifle.lr300",
                Name = "LR-300 Assault Rifle",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1716193401"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "smg.mp5",
                Name = "MP5A4",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-2094080303"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "pistol.m92",
                Name = "M92 Pistol",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "371156815"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "pistol.python",
                Name = "Python Revolver",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "2033918259"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "pistol.nailgun",
                Name = "Nailgun",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "449769971"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "shotgun.spas12",
                Name = "Spas-12 Shotgun",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "621575320"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "rifle.l96",
                Name = "L96 Rifle",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-778367295"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "rifle.m39",
                Name = "M39 Rifle",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "28201841"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "charcoal",
                Name = "Charcoal",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1436001773"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "cloth",
                Name = "Cloth",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "94756378"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "explosives",
                Name = "Explosives",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1755466030"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "fat.animal",
                Name = "Animal Fat",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1034048911"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "gunpowder",
                Name = "Gun Powder",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1580059655"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "hq.metal.ore",
                Name = "High Quality Metal Ore",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "2133577942"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "leather",
                Name = "Leather",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "50834473"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "metal.fragments",
                Name = "Metal Fragments",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "688032252"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "metal.ore",
                Name = "Metal Ore",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1059362949"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "metal.refined",
                Name = "High Quality Metal",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "374890416"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "sulfur",
                Name = "Sulfur",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-891243783"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "sulfur.ore",
                Name = "Sulfur Ore",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "889398893"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "wood",
                Name = "Wood",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "3655341"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.handmade.shell",
                Name = "Handmade Shell",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "2115555558"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.rifle",
                Name = "5.56 Rifle Ammo",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "815896488"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.rifle.explosive",
                Name = "Explosive 5.56 Rifle Ammo",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "805088543"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.rifle.hv",
                Name = "HV 5.56 Rifle Ammo",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1152393492"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.rifle.incendiary",
                Name = "Incendiary 5.56 Rifle Ammo",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "449771810"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.rocket.basic",
                Name = "Rocket",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1578894260"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.rocket.fire",
                Name = "Incendiary Rocket",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1436532208"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.rocket.hv",
                Name = "High Velocity Rocket",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "542276424"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.pistol",
                Name = "Pistol Bullet",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-533875561"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.pistol.fire",
                Name = "Incendiary Pistol Bullet",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1621541165"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.pistol.hv",
                Name = "HV Pistol Ammo",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-422893115"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.rocket.smoke",
                Name = "Smoke Rocket WIP!!!!",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1594947829"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.shotgun",
                Name = "12 Gauge Buckshot",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1035059994"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.shotgun.slug",
                Name = "12 Gauge Slug",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1819281075"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ammo.shotgun.fire",
                Name = "12 Gauge Incendiary Shell",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1818890814"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "arrow.hv",
                Name = "High Velocity Arrow",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1280058093"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "arrow.wooden",
                Name = "Wooden Arrow",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-420273765"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "arrow.bone",
                Name = "Bone Arrow",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1775362679"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "arrow.fire",
                Name = "Fire Arrow",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1775249157"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "bucket.helmet",
                Name = "Bucket Helmet",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1260209393"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "coffeecan.helmet",
                Name = "Coffee Can Helmet",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-2128719593"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "hoodie",
                Name = "Hoodie",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1211618504"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "jacket",
                Name = "Jacket",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1167640370"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "jacket.snow",
                Name = "Snow Jacket - Red",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1616887133"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "jackolantern.angry",
                Name = "Jack O Lantern Angry",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1284735799"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "jackolantern.happy",
                Name = "Jack O Lantern Happy",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1278649848"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "mask.balaclava",
                Name = "Improvised Balaclava",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "997973965"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "metal.facemask",
                Name = "Metal Facemask",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-46848560"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "metal.plate.torso",
                Name = "Metal Chest Plate",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1265861812"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "riot.helmet",
                Name = "Riot Helmet",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "340009023"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "roadsign.jacket",
                Name = "Road Sign Jacket",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-288010497"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "pants.shorts",
                Name = "Shorts",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-459156023"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "shirt.collared",
                Name = "Shirt",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "24576628"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "shirt.tanktop",
                Name = "Tank Top",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1659202509"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "heavy.plate.helmet",
                Name = "Heavy Plate Helmet",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1351172108"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "heavy.plate.jacket",
                Name = "Heavy Plate Jacket",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1404466285"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "heavy.plate.pants",
                Name = "Heavy Plate Pants",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1334615971"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "facialhair.style01",
                Name = "Facial Hair Style 01",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "726730162"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "female_hairstyle_01",
                Name = "Female Hairstyle 01",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "305916740"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "female_hairstyle_02",
                Name = "Female Hairstyle 02",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "305916741"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "femalearmpithair.style01",
                Name = "Female Armpit Hair 01",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "252529905"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "femaleeyebrow.style01",
                Name = "Female Eyebrow 01",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "471582113"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "femalepubichair.style01",
                Name = "Female Pubic Hair 01",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1138648591"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "male_hairstyle_01",
                Name = "Male Hairstyle 01",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1832205789"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "male_hairstyle_02",
                Name = "Male Hairstyle 02",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1832205788"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "malearmpithair.style01",
                Name = "Male Armpit Hair 01",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1625090418"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "maleeyebrow.style01",
                Name = "Male Eyebrow 01",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1269800768"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "malepubichair.style01",
                Name = "Male Pubic Hair 01",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "429648208"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "clatter.helmet",
                Name = "Clatter Helmet",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "968019378"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "barricade.concrete",
                Name = "Concrete Barricade",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "498312426"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "barricade.metal",
                Name = "Metal Barricade",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "504904386"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "barricade.sandbags",
                Name = "Sandbag Barricade",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1221200300"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "barricade.stone",
                Name = "Stone Barricade",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "510887968"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "barricade.woodwire",
                Name = "Barbed Wooden Barricade",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1024486167"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "bed",
                Name = "Bed",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "97409"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ceilinglight",
                Name = "Ceiling Light",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-2095387015"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "furnace.large",
                Name = "Large Furnace",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1598149413"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "gates.external.high.stone",
                Name = "High External Stone Gate",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1779401418"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "	gates.external.high.wood",
                Name = "High External Wooden Gate",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-57285700"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "shelves",
                Name = "Salvaged Shelves",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "2057749608"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "shutter.metal.embrasure.a",
                Name = "Metal horizontal embrasure",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-529054135"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "shutter.metal.embrasure.b",
                Name = "Metal Vertical embrasure",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-529054134"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "shutter.wood.a",
                Name = "Wood Shutters",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "486166145"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "wall.external.high",
                Name = "High External Wooden Wall",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1792066367"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "wall.external.high.stone",
                Name = "High External Stone Wall",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-496055048"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "water.barrel",
                Name = "Water Barrel",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1628526499"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "planter.large",
                Name = "Large Planter Box",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "142147109"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "planter.small",
                Name = "Small Planter Box",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "148953073"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "chair",
                Name = "Chair",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "94623429"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "door.closer",
                Name = "Door Closer",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-778796102"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "small.oil.refinery",
                Name = "Small Oil Refinery",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "470729623"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "table",
                Name = "Table",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "110115790"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "rug",
                Name = "Rug",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "113284"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "rug.bear",
                Name = "Rug Bear Skin",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "569935070"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "locker",
                Name = "Locker",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1097452776"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "wall.frame.netting",
                Name = "Netting",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "313836902"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "workbench1",
                Name = "Work Bench Level 1",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-481416622"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "workbench2",
                Name = "Work Bench Level 2",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-481416621"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "workbench3",
                Name = "Work Bench Level 3",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-481416620"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "wall.frame.garagedoor",
                Name = "Garage Door",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "447918618"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "axe.salvaged",
                Name = "Salvaged Axe",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "790921853"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "hammer.salvaged",
                Name = "Salvaged Hammer",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1976561211"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "hatchet",
                Name = "Hatchet",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "698310895"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "icepick.salvaged",
                Name = "Salvaged Icepick",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1440143841"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "pickaxe",
                Name = "Pick Axe",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-578028723"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "salvaged.cleaver",
                Name = "Salvaged Cleaver",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1775234707"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "salvaged.sword",
                Name = "Salvaged Sword",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-388967316"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "surveycharge",
                Name = "Survey Charge",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1293049486"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "bucket.water",
                Name = "Water Bucket",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1192532973"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "chainsaw",
                Name = "Chainsaw",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1428021640"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "antiradpills",
                Name = "Anti-Radiation Pills",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1685058759"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "bandage",
                Name = "Bandage",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-337261910"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "largemedkit",
                Name = "Large Medkit",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-789202811"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "	syringe.medical",
                Name = "Medical Syringe",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "586484018"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "apple",
                Name = "Apple",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "93029210"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "bearmeat.cooked",
                Name = "Bear Meat Cooked",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-2043730634"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "black.raspberries",
                Name = "Black Raspberries",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1611480185"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "blueberries",
                Name = "Blueberries",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1063412582"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "chicken.cooked",
                Name = "Cooked Chicken",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1734319168"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "chocholate",
                Name = "Chocolate Bar",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-341443994"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "granolabar",
                Name = "Granola Bar",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "718197703"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "wolfmeat.cooked",
                Name = "Cooked Wolf Meat",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1691991080"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "cakefiveyear",
                Name = "Birthday Cake",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1973165031"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "autoturret",
                Name = "Auto Turret",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "563023711"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "box.wooden.large",
                Name = "Large Wood Box",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "271534758"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "cctv.camera",
                Name = "CCTV Camera",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1300054961"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "fun.guitar",
                Name = "Acoustic Guitar",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-217113639"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "lock.code",
                Name = "Code Lock",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-975723312"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "targeting.computer",
                Name = "Targeting Computer",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1490499512"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "trap.landmine",
                Name = "Land Mine",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "255101535"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "weapon.mod.flashlight",
                Name = "Weapon Flashlight",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1229879204"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "weapon.mod.holosight",
                Name = "Holosight",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-465236267"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "weapon.mod.lasersight",
                Name = "Weapon Lasersight",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "516382256"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "weapon.mod.silencer",
                Name = "Silencer",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1213686767"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "weapon.mod.8x.scope",
                Name = "8x Zoom Scope",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-141135377"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "weapon.mod.muzzlebrake",
                Name = "Muzzle Brake",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1569280852"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "weapon.mod.muzzleboost",
                Name = "Muzzle Boost",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1569356508"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "flameturret",
                Name = "Flame Turret",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1985408483"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "tunalight",
                Name = "Tuna Can Lamp",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "260214178"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "vending.machine",
                Name = "Vending Machine",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1847536522"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "wall.frame.shopfront.metal",
                Name = "Metal Shop Front",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "525244071"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "fridge",
                Name = "Fridge",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1266285051"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "spinner.wheel",
                Name = "Spinning wheel",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "552706886"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "tool.binoculars",
                Name = "Binoculars",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1480119738"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "weapon.mod.simplesight",
                Name = "Simple Handmade Sight",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "386382445"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "searchlight",
                Name = "Search Light",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-527558546"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "scrap",
                Name = "Scrap",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "109266897"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "mailbox",
                Name = "Mail Box",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "830965940"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "waterjug",
                Name = "Water Jug",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "547302405"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "dropbox",
                Name = "Drop Box",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1925723260"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "guntrap",
                Name = "Shotgun Trap",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "378365037"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "gloweyes",
                Name = "Glowing Eyes",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-522149009"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "scarecrow",
                Name = "Scarecrow",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1705696613"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "skull_fire_pit",
                Name = "Skull Fire Pit",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1859976884"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "bbq",
                Name = "Barbeque",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "97329"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "flashlight.held",
                Name = "Flashlight",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1496470781"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.random.switch",
                Name = "RAND Switch",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1171735914"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.battery.rechargable.large",
                Name = "Large Rechargable Battery",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "553270375"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.battery.rechargable.small",
                Name = "Small Rechargable Battery",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-692338819"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.blocker",
                Name = "Blocker",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-690968985"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.cabletunnel",
                Name = "Cable Tunnel",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1835946060"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.counter",
                Name = "Counter",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-216999575"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.doorcontroller",
                Name = "Door Controller",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-502177121"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.fuelgenerator.small",
                Name = "Small Generator",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-295829489"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.laserdetector",
                Name = "Laser Detector",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-798293154"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.orswitch",
                Name = "OR Switch",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1286302544"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.pressurepad",
                Name = "Pressure Pad",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-2049214035"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.simplelight",
                Name = "Simple Light",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-282113991"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.solarpanel.large",
                Name = "Large Solar Panel",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "2090395347"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.splitter",
                Name = "Splitter",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-563624462"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.switch",
                Name = "Switch",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1951603367"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.timer",
                Name = "Timer",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "665332906"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electric.xorswitch",
                Name = "XOR Switch",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1293102274"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electrical.branch",
                Name = "Electrical Branch",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1448252298"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electrical.combiner",
                Name = "Root Combiner",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-458565393"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "electrical.memorycell",
                Name = "Memory Cell",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-746647361"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "partyhat",
                Name = "Party Hat",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-575744869"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "wiretool",
                Name = "Wire Tool",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-144417939"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "bleach",
                Name = "Bleach",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1386464949"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "ducttape",
                Name = "Duct Tape",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1891056868"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "gears",
                Name = "Gears",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "98228420"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "glue",
                Name = "Glue",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "3175989"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "metalblade",
                Name = "Metal Blade",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1567404401"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "metalpipe",
                Name = "Metal Pipe",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1057402571"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "metalspring",
                Name = "Metal Spring",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1835797460"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "propanetank",
                Name = "Empty Propane Tank",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1974032895"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "riflebody",
                Name = "Rifle Body",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1939428458"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "roadsigns",
                Name = "Road Signs",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-847065290"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "rope",
                Name = "Rope",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "3506418"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "sewingkit",
                Name = "Sewing Kit",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-419069863"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "sheetmetal",
                Name = "Sheet Metal",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1617374968"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "sticks",
                Name = "Sticks",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-892259869"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "tarp",
                Name = "Tarp",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "3552619"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "techparts",
                Name = "Tech Trash",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1471284746"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "attire.reindeer.headband",
                Name = "Reindeer Antlers",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-966287254"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "candycaneclub",
                Name = "Candy Cane Club",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1693683664"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "fireplace.stone",
                Name = "Stone Fireplace",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1908328648"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "snowman",
                Name = "Snowman",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-2055888649"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "xmas.lightstring",
                Name = "Christmas Lights",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1151126752"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "xmas.tree",
                Name = "Christmas Tree",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-1926458555"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "xmas.window.garland",
                Name = "Festive Window Garland",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "-460592212"
            },
            new RustItem
            {
                Id = Guid.NewGuid(),
                RustItemInGameId = "xmasdoorwreath",
                Name = "Christmas Door Wreath",
                
                
                RustItemType = DefaultRustItemTypes.Find(x => x.TypeName == "Item"),
                ImgUrl = "1540879296"
            }
        };
    }
}

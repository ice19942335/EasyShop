﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyShop.DAL.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    ProfileImage = table.Column<string>(nullable: true),
                    ShopsAllowed = table.Column<int>(nullable: false),
                    TransactionPercent = table.Column<int>(nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    UsingTariff = table.Column<bool>(nullable: false),
                    PurchasedTariffs = table.Column<string>(maxLength: 10000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BugReportCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Index = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BugReportCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DevBlogPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    PostMessage = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    ImgDeleteHash = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    LinkTitle = table.Column<string>(nullable: true),
                    DateTimePosted = table.Column<DateTime>(nullable: false),
                    LikesCounter = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevBlogPosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneralSupportReportCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Category = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralSupportReportCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    LinkTitle = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    DateTimeCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Index = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RustItemTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RustItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RustServerMaps",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RustServerMaps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SteamUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Uid = table.Column<string>(nullable: true),
                    TotalSpent = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SteamUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TariffOptionDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffOptionDescriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tariffs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DaysActive = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tariffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DevBlogPostsLikes",
                columns: table => new
                {
                    DevBlogPostId = table.Column<Guid>(nullable: false),
                    AppUserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevBlogPostsLikes", x => new { x.AppUserId, x.DevBlogPostId });
                    table.ForeignKey(
                        name: "FK_DevBlogPostsLikes_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DevBlogPostsLikes_DevBlogPosts_DevBlogPostId",
                        column: x => x.DevBlogPostId,
                        principalTable: "DevBlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ShopName = table.Column<string>(nullable: false),
                    GameTypeId = table.Column<int>(nullable: false),
                    ShopTitle = table.Column<string>(nullable: false),
                    StartBalance = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Secret = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shops_GameTypes_GameTypeId",
                        column: x => x.GameTypeId,
                        principalTable: "GameTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserNotifications",
                columns: table => new
                {
                    AppUserId = table.Column<string>(nullable: false),
                    NotificationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotifications", x => new { x.AppUserId, x.NotificationId });
                    table.ForeignKey(
                        name: "FK_UserNotifications_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNotifications_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BugReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    BugReportCategoryId = table.Column<Guid>(nullable: false),
                    StatusId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: true),
                    DeleteHash = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BugReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BugReports_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BugReports_BugReportCategories_BugReportCategoryId",
                        column: x => x.BugReportCategoryId,
                        principalTable: "BugReportCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BugReports_ReportStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ReportStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollaborationReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StatusId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaborationReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollaborationReports_ReportStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ReportStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneralSupportReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: false),
                    StatusId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralSupportReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralSupportReports_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GeneralSupportReports_GeneralSupportReportCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "GeneralSupportReportCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralSupportReports_ReportStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ReportStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RustItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RustItemInGameId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    RustItemTypeId = table.Column<Guid>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RustItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RustItems_RustItemTypes_RustItemTypeId",
                        column: x => x.RustItemTypeId,
                        principalTable: "RustItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TariffOptions",
                columns: table => new
                {
                    TariffOptionDescriptionId = table.Column<int>(nullable: false),
                    TariffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffOptions", x => new { x.TariffOptionDescriptionId, x.TariffId });
                    table.ForeignKey(
                        name: "FK_TariffOptions_Tariffs_TariffId",
                        column: x => x.TariffId,
                        principalTable: "Tariffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TariffOptions_TariffOptionDescriptions_TariffOptionDescriptionId",
                        column: x => x.TariffOptionDescriptionId,
                        principalTable: "TariffOptionDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTariffs",
                columns: table => new
                {
                    TariffId = table.Column<int>(nullable: false),
                    AppUserId = table.Column<string>(nullable: false),
                    PurchaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTariffs", x => new { x.AppUserId, x.TariffId });
                    table.ForeignKey(
                        name: "FK_UserTariffs_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTariffs_Tariffs_TariffId",
                        column: x => x.TariffId,
                        principalTable: "Tariffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayPalCreatedPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ShopId = table.Column<Guid>(nullable: true),
                    SteamUserId = table.Column<Guid>(nullable: true),
                    AmountToPay = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    ParsedPayPalSdkPayment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayPalCreatedPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayPalCreatedPayments_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PayPalCreatedPayments_SteamUsers_SteamUserId",
                        column: x => x.SteamUserId,
                        principalTable: "SteamUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PayPalExecutedPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ShopId = table.Column<Guid>(nullable: true),
                    SteamUserId = table.Column<Guid>(nullable: true),
                    AmountPaid = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PaymentDateTime = table.Column<DateTime>(nullable: false),
                    ParsedPayPalSdkPayment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayPalExecutedPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayPalExecutedPayments_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PayPalExecutedPayments_SteamUsers_SteamUserId",
                        column: x => x.SteamUserId,
                        principalTable: "SteamUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "RustCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Index = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    ShopId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RustCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RustCategories_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RustCategories_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RustServers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    NameInShop = table.Column<string>(nullable: false),
                    Index = table.Column<int>(nullable: false),
                    IpAddress = table.Column<string>(nullable: false),
                    Port = table.Column<int>(nullable: false),
                    ShowInShop = table.Column<bool>(nullable: false),
                    ShopId = table.Column<Guid>(nullable: false),
                    ServerMapId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RustServers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RustServers_RustServerMaps_ServerMapId",
                        column: x => x.ServerMapId,
                        principalTable: "RustServerMaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RustServers_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SteamUserShops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopId = table.Column<Guid>(nullable: true),
                    SteamUserId = table.Column<Guid>(nullable: true),
                    StartBalance = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TotalSpent = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TotalToppedUp = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SteamUserShops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SteamUserShops_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SteamUserShops_SteamUsers_SteamUserId",
                        column: x => x.SteamUserId,
                        principalTable: "SteamUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "UserShops",
                columns: table => new
                {
                    ShopId = table.Column<Guid>(nullable: false),
                    AppUserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserShops", x => new { x.AppUserId, x.ShopId });
                    table.ForeignKey(
                        name: "FK_UserShops_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserShops_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RustPurchasedItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SteamUserId = table.Column<Guid>(nullable: true),
                    RustItemId = table.Column<Guid>(nullable: true),
                    PurchaseDateTime = table.Column<DateTime>(nullable: false),
                    TotalPaid = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ItemsPerStack = table.Column<int>(nullable: false),
                    AmountLeft = table.Column<int>(nullable: false),
                    AmountOnPurchase = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RustPurchasedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RustPurchasedItems_RustItems_RustItemId",
                        column: x => x.RustItemId,
                        principalTable: "RustItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RustPurchasedItems_SteamUsers_SteamUserId",
                        column: x => x.SteamUserId,
                        principalTable: "SteamUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "RustUserItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RustCategoryId = table.Column<Guid>(nullable: false),
                    RustItemId = table.Column<Guid>(nullable: false),
                    ShopId = table.Column<Guid>(nullable: false),
                    AppUserId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ItemsPerStack = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Discount = table.Column<int>(nullable: false),
                    BlockedTill = table.Column<DateTime>(nullable: false),
                    ShowInShop = table.Column<bool>(nullable: false),
                    Index = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RustUserItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RustUserItems_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RustUserItems_RustCategories_RustCategoryId",
                        column: x => x.RustCategoryId,
                        principalTable: "RustCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RustUserItems_RustItems_RustItemId",
                        column: x => x.RustItemId,
                        principalTable: "RustItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RustUserItems_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RustPurchaseStats",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    RustPurchasedItemId = table.Column<Guid>(nullable: true),
                    ShopId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RustPurchaseStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RustPurchaseStats_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RustPurchaseStats_RustPurchasedItems_RustPurchasedItemId",
                        column: x => x.RustPurchasedItemId,
                        principalTable: "RustPurchasedItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RustPurchaseStats_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BugReports_AppUserId",
                table: "BugReports",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BugReports_BugReportCategoryId",
                table: "BugReports",
                column: "BugReportCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BugReports_StatusId",
                table: "BugReports",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CollaborationReports_StatusId",
                table: "CollaborationReports",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DevBlogPostsLikes_DevBlogPostId",
                table: "DevBlogPostsLikes",
                column: "DevBlogPostId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralSupportReports_AppUserId",
                table: "GeneralSupportReports",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralSupportReports_CategoryId",
                table: "GeneralSupportReports",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralSupportReports_StatusId",
                table: "GeneralSupportReports",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PayPalCreatedPayments_ShopId",
                table: "PayPalCreatedPayments",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_PayPalCreatedPayments_SteamUserId",
                table: "PayPalCreatedPayments",
                column: "SteamUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PayPalExecutedPayments_ShopId",
                table: "PayPalExecutedPayments",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_PayPalExecutedPayments_SteamUserId",
                table: "PayPalExecutedPayments",
                column: "SteamUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RustCategories_AppUserId",
                table: "RustCategories",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RustCategories_ShopId",
                table: "RustCategories",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_RustItems_RustItemTypeId",
                table: "RustItems",
                column: "RustItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RustPurchasedItems_RustItemId",
                table: "RustPurchasedItems",
                column: "RustItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RustPurchasedItems_SteamUserId",
                table: "RustPurchasedItems",
                column: "SteamUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RustPurchaseStats_AppUserId",
                table: "RustPurchaseStats",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RustPurchaseStats_RustPurchasedItemId",
                table: "RustPurchaseStats",
                column: "RustPurchasedItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RustPurchaseStats_ShopId",
                table: "RustPurchaseStats",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_RustServers_ServerMapId",
                table: "RustServers",
                column: "ServerMapId");

            migrationBuilder.CreateIndex(
                name: "IX_RustServers_ShopId",
                table: "RustServers",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_RustUserItems_AppUserId",
                table: "RustUserItems",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RustUserItems_RustCategoryId",
                table: "RustUserItems",
                column: "RustCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RustUserItems_RustItemId",
                table: "RustUserItems",
                column: "RustItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RustUserItems_ShopId",
                table: "RustUserItems",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_GameTypeId",
                table: "Shops",
                column: "GameTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SteamUserShops_ShopId",
                table: "SteamUserShops",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_SteamUserShops_SteamUserId",
                table: "SteamUserShops",
                column: "SteamUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TariffOptions_TariffId",
                table: "TariffOptions",
                column: "TariffId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_NotificationId",
                table: "UserNotifications",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserShops_ShopId",
                table: "UserShops",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTariffs_TariffId",
                table: "UserTariffs",
                column: "TariffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BugReports");

            migrationBuilder.DropTable(
                name: "CollaborationReports");

            migrationBuilder.DropTable(
                name: "DevBlogPostsLikes");

            migrationBuilder.DropTable(
                name: "GeneralSupportReports");

            migrationBuilder.DropTable(
                name: "PayPalCreatedPayments");

            migrationBuilder.DropTable(
                name: "PayPalExecutedPayments");

            migrationBuilder.DropTable(
                name: "RustPurchaseStats");

            migrationBuilder.DropTable(
                name: "RustServers");

            migrationBuilder.DropTable(
                name: "RustUserItems");

            migrationBuilder.DropTable(
                name: "SteamUserShops");

            migrationBuilder.DropTable(
                name: "TariffOptions");

            migrationBuilder.DropTable(
                name: "UserNotifications");

            migrationBuilder.DropTable(
                name: "UserShops");

            migrationBuilder.DropTable(
                name: "UserTariffs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BugReportCategories");

            migrationBuilder.DropTable(
                name: "DevBlogPosts");

            migrationBuilder.DropTable(
                name: "GeneralSupportReportCategories");

            migrationBuilder.DropTable(
                name: "ReportStatus");

            migrationBuilder.DropTable(
                name: "RustPurchasedItems");

            migrationBuilder.DropTable(
                name: "RustServerMaps");

            migrationBuilder.DropTable(
                name: "RustCategories");

            migrationBuilder.DropTable(
                name: "TariffOptionDescriptions");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Tariffs");

            migrationBuilder.DropTable(
                name: "RustItems");

            migrationBuilder.DropTable(
                name: "SteamUsers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "RustItemTypes");

            migrationBuilder.DropTable(
                name: "GameTypes");
        }
    }
}

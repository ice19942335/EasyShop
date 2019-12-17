using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyShop.DAL.Migrations
{
    public partial class Added_ShopTables_Edited_dAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TariffLastUpdate",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseDate",
                table: "UserTariffs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<decimal>(
                name: "TransactionPercent",
                table: "AspNetUsers",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "PurchasedTariffs",
                table: "AspNetUsers",
                maxLength: 10000,
                nullable: true);

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
                name: "Servers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    NameInShop = table.Column<string>(nullable: false),
                    IndexInList = table.Column<string>(nullable: false),
                    IpAddress = table.Column<string>(nullable: false),
                    Port = table.Column<int>(nullable: false),
                    Map = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "ServerShops",
                columns: table => new
                {
                    ShopId = table.Column<int>(nullable: false),
                    ServerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerShops", x => new { x.ServerId, x.ShopId });
                    table.ForeignKey(
                        name: "FK_ServerShops_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServerShops_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserShops",
                columns: table => new
                {
                    ShopId = table.Column<int>(nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_ServerShops_ShopId",
                table: "ServerShops",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_GameTypeId",
                table: "Shops",
                column: "GameTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserShops_ShopId",
                table: "UserShops",
                column: "ShopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServerShops");

            migrationBuilder.DropTable(
                name: "UserShops");

            migrationBuilder.DropTable(
                name: "Servers");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "GameTypes");

            migrationBuilder.DropColumn(
                name: "PurchaseDate",
                table: "UserTariffs");

            migrationBuilder.DropColumn(
                name: "PurchasedTariffs",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionPercent",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "TariffLastUpdate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);
        }
    }
}

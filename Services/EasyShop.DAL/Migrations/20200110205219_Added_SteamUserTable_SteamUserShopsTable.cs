using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyShop.DAL.Migrations
{
    public partial class Added_SteamUserTable_SteamUserShopsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SteamUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Uid = table.Column<string>(nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SteamUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SteamUserShops",
                columns: table => new
                {
                    AppUserId = table.Column<string>(nullable: false),
                    SteamUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SteamUserShops", x => new { x.AppUserId, x.SteamUserId });
                    table.ForeignKey(
                        name: "FK_SteamUserShops_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SteamUserShops_SteamUsers_SteamUserId",
                        column: x => x.SteamUserId,
                        principalTable: "SteamUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SteamUserShops_SteamUserId",
                table: "SteamUserShops",
                column: "SteamUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SteamUserShops");

            migrationBuilder.DropTable(
                name: "SteamUsers");
        }
    }
}

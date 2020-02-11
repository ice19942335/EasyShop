using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyShop.DAL.Migrations
{
    public partial class Added_PayPal_Payment_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayPalExecutedPayments_SteamUsers_SteamUserId",
                        column: x => x.SteamUserId,
                        principalTable: "SteamUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayPalCreatedPayments");

            migrationBuilder.DropTable(
                name: "PayPalExecutedPayments");
        }
    }
}

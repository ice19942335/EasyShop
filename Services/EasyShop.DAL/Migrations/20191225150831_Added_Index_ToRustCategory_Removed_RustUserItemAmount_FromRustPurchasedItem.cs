using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyShop.DAL.Migrations
{
    public partial class Added_Index_ToRustCategory_Removed_RustUserItemAmount_FromRustPurchasedItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RustUserItemAmount",
                table: "RustPurchasedItems");

            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "RustCategories",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Index",
                table: "RustCategories");

            migrationBuilder.AddColumn<int>(
                name: "RustUserItemAmount",
                table: "RustPurchasedItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

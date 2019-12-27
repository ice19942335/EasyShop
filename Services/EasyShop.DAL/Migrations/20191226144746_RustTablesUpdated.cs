using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyShop.DAL.Migrations
{
    public partial class RustTablesUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Discount",
                table: "RustUserItems",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AddColumn<bool>(
                name: "ShowInShop",
                table: "RustUserItems",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowInShop",
                table: "RustUserItems");

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "RustUserItems",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyShop.DAL.Migrations
{
    public partial class AppUser_AddedColumn_TotalRevenue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalRevenue",
                table: "AspNetUsers",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalRevenue",
                table: "AspNetUsers");
        }
    }
}

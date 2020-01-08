using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyShop.DAL.Migrations
{
    public partial class Added_DevBlog_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DevBlogPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    PostMessage = table.Column<string>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_DevBlogPostsLikes_DevBlogPostId",
                table: "DevBlogPostsLikes",
                column: "DevBlogPostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevBlogPostsLikes");

            migrationBuilder.DropTable(
                name: "DevBlogPosts");
        }
    }
}

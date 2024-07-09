using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitterApi.DAL.Migrations
{
    public partial class PostReaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Blogs_BlogId",
                table: "Files");

            migrationBuilder.DropTable(
                name: "BlogTopic");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9006f91e-5138-4181-996b-88eeaa3125bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca6332cf-ca23-4b16-a6fe-3270f04f0dda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8593f16-0526-46b8-937f-1913e306f366");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "Files",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Files_BlogId",
                table: "Files",
                newName: "IX_Files_PostId");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostReaction",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Reaction = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostReaction", x => new { x.PostId, x.AppUserId });
                    table.ForeignKey(
                        name: "FK_PostReaction_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostReaction_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostTopic",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTopic", x => new { x.PostId, x.TopicId });
                    table.ForeignKey(
                        name: "FK_PostTopic_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostTopic_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "780f0f19-ebe9-4c05-98d3-191094234371", "32463528-2354-44cc-9664-113559ace523", "Moderator", "MODERATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "97cfaee7-03f4-4385-8cdf-df24730a6834", "58613990-05a1-42fd-91b4-d5e010173c2b", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad39b897-eacd-45c7-90fd-8aff86c7429a", "31d09d47-0738-464d-a0bc-190a97c68220", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_PostReaction_AppUserId",
                table: "PostReaction",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTopic_TopicId",
                table: "PostTopic",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Posts_PostId",
                table: "Files",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Posts_PostId",
                table: "Files");

            migrationBuilder.DropTable(
                name: "PostReaction");

            migrationBuilder.DropTable(
                name: "PostTopic");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "780f0f19-ebe9-4c05-98d3-191094234371");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97cfaee7-03f4-4385-8cdf-df24730a6834");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad39b897-eacd-45c7-90fd-8aff86c7429a");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Files",
                newName: "BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_Files_PostId",
                table: "Files",
                newName: "IX_Files_BlogId");

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BlogTopic",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTopic", x => new { x.BlogId, x.TopicId });
                    table.ForeignKey(
                        name: "FK_BlogTopic_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BlogTopic_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9006f91e-5138-4181-996b-88eeaa3125bf", "c2efa6e9-22c0-4d22-8a51-536f3843e343", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ca6332cf-ca23-4b16-a6fe-3270f04f0dda", "80ae1b97-7638-4cc5-b9b7-c18cbaed044a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d8593f16-0526-46b8-937f-1913e306f366", "f756fe1b-7e31-46c5-b498-2fd445c9ae73", "Moderator", "MODERATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserId",
                table: "Blogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogTopic_TopicId",
                table: "BlogTopic",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Blogs_BlogId",
                table: "Files",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id");
        }
    }
}

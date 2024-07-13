using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitterApi.DAL.Migrations
{
    public partial class updatePostReaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PostReaction",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0156acea-9cc4-428d-9309-db930149f6e4", "5c1022a3-be24-4bda-81a0-ab92cab7a922", "Moderator", "MODERATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "19f56346-d157-4275-bf66-979b9ced462f", "eb28ecdf-b9ad-4293-9ba4-20baab96ec2a", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7944fc9-eba6-43b8-abb7-6627e78176be", "9a1eb313-88b0-4bbd-bad8-52d041f3dffd", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0156acea-9cc4-428d-9309-db930149f6e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19f56346-d157-4275-bf66-979b9ced462f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7944fc9-eba6-43b8-abb7-6627e78176be");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PostReaction");

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
        }
    }
}

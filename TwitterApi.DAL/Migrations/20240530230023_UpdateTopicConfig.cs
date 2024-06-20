using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitterApi.DAL.Migrations
{
    public partial class UpdateTopicConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f7aed86-847b-461f-93f4-4b41cc8e5d20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f271d4e-36ad-4584-b120-a7428b1075b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8952efb-7081-44ab-8607-eaca0b05866c");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5f7aed86-847b-461f-93f4-4b41cc8e5d20", "6d68daea-27be-45f2-84e2-35f529bf3f6a", "Moderator", "MODERATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f271d4e-36ad-4584-b120-a7428b1075b1", "86e8d690-673c-45ab-9892-812c326527b4", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b8952efb-7081-44ab-8607-eaca0b05866c", "23c3fb2e-75f0-4d76-9389-c84491bc35c2", "Admin", "ADMIN" });
        }
    }
}

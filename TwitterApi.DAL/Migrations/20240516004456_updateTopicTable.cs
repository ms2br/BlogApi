using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitterApi.DAL.Migrations
{
    public partial class updateTopicTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Topics_Name",
                table: "Topics");

            migrationBuilder.AddColumn<string>(
                name: "NormalizedTopicName",
                table: "Topics",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_NormalizedTopicName",
                table: "Topics",
                column: "NormalizedTopicName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Topics_NormalizedTopicName",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "NormalizedTopicName",
                table: "Topics");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_Name",
                table: "Topics",
                column: "Name",
                unique: true);
        }
    }
}

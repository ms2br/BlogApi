using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitterApi.DAL.Migrations
{
    public partial class updateall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Topics_Name",
                table: "Topics",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Topics_Name",
                table: "Topics");
        }
    }
}

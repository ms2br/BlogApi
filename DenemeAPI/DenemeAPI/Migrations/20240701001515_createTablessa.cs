using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DenemeAPI.Migrations
{
    /// <inheritdoc />
    public partial class createTablessa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentUser");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "School",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Branch",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "School",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "StudentUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentUser_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}

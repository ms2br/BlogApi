using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DenemeAPI.Migrations
{
    /// <inheritdoc />
    public partial class createTablesss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherUser_Users_Id",
                table: "TeacherUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherUser",
                table: "TeacherUser");

            migrationBuilder.RenameTable(
                name: "TeacherUser",
                newName: "Teachers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Users_Id",
                table: "Teachers",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Users_Id",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "TeacherUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherUser",
                table: "TeacherUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherUser_Users_Id",
                table: "TeacherUser",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStudentEntityWithAnnotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Student",
                newName: "St_Name");

            migrationBuilder.RenameColumn(
                name: "Grade",
                table: "Student",
                newName: "St_Grade");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Student",
                newName: "St_Age");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Student",
                newName: "St_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "St_Name",
                table: "Student",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "St_Grade",
                table: "Student",
                newName: "Grade");

            migrationBuilder.RenameColumn(
                name: "St_Age",
                table: "Student",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "St_ID",
                table: "Student",
                newName: "Id");
        }
    }
}

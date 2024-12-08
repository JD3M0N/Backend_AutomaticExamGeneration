using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInheritanceMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "St_Grade",
                table: "Student",
                newName: "Course");

            migrationBuilder.RenameColumn(
                name: "St_Age",
                table: "Student",
                newName: "E_Age");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "E_Age",
                table: "Student",
                newName: "St_Age");

            migrationBuilder.RenameColumn(
                name: "Course",
                table: "Student",
                newName: "St_Grade");
        }
    }
}

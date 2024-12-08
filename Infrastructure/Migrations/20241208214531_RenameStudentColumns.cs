using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class RenameStudentColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "St_Age",
                table: "Student",
                newName: "E_Age");

            migrationBuilder.RenameColumn(
                name: "St_Grade",
                table: "Student",
                newName: "Course");
        }

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

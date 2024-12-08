using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SetUIdAsIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_User_Id",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_Professor_User_Id",
                table: "Professor");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_User_Id",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "rol",
                table: "User",
                newName: "Rol");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "User",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "UName",
                table: "User",
                newName: "U_Name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "User",
                newName: "Gmail");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "User",
                newName: "U_ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Student",
                newName: "U_ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Professor",
                newName: "U_ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Admin",
                newName: "U_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_User_U_ID",
                table: "Admin",
                column: "U_ID",
                principalTable: "User",
                principalColumn: "U_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_User_U_ID",
                table: "Professor",
                column: "U_ID",
                principalTable: "User",
                principalColumn: "U_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_User_U_ID",
                table: "Student",
                column: "U_ID",
                principalTable: "User",
                principalColumn: "U_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_User_U_ID",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_Professor_User_U_ID",
                table: "Professor");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_User_U_ID",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "Rol",
                table: "User",
                newName: "rol");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "U_Name",
                table: "User",
                newName: "UName");

            migrationBuilder.RenameColumn(
                name: "Gmail",
                table: "User",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "U_ID",
                table: "User",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "U_ID",
                table: "Student",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "U_ID",
                table: "Professor",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "U_ID",
                table: "Admin",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_User_Id",
                table: "Admin",
                column: "Id",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_User_Id",
                table: "Professor",
                column: "Id",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_User_Id",
                table: "Student",
                column: "Id",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

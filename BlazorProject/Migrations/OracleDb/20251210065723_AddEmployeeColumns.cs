using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorProject.Migrations.OracleDb
{
    /// <inheritdoc />
    public partial class AddEmployeeColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "role",
                table: "EMPLOYEES",
                newName: "ROLE");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "EMPLOYEES",
                newName: "EMAIL");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "EMPLOYEES",
                newName: "PHONENUMBER");

            migrationBuilder.AlterColumn<string>(
                name: "ROLE",
                table: "EMPLOYEES",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "EMPLOYEES",
                type: "NVARCHAR2(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ROLE",
                table: "EMPLOYEES",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "PHONENUMBER",
                table: "EMPLOYEES",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "EMPLOYEES",
                newName: "email");

            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "EMPLOYEES",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "EMPLOYEES",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(255)",
                oldMaxLength: 255,
                oldNullable: true);
        }
    }
}

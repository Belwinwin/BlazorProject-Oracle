using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorProject.Migrations.OracleDbContext3Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdUserNameToRegistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "USERID",
                table: "REGISTRATIONDETAILS",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "USERNAME",
                table: "REGISTRATIONDETAILS",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "USERID",
                table: "REGISTRATIONDETAILS");

            migrationBuilder.DropColumn(
                name: "USERNAME",
                table: "REGISTRATIONDETAILS");
        }
    }
}

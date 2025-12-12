using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorProject.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EMPLOYEE_DETAILS",
                table: "EMPLOYEE_DETAILS");

            migrationBuilder.RenameTable(
                name: "EMPLOYEE_DETAILS",
                newName: "EMPLOYEEDETAILS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EMPLOYEEDETAILS",
                table: "EMPLOYEEDETAILS",
                column: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EMPLOYEEDETAILS",
                table: "EMPLOYEEDETAILS");

            migrationBuilder.RenameTable(
                name: "EMPLOYEEDETAILS",
                newName: "EMPLOYEE_DETAILS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EMPLOYEE_DETAILS",
                table: "EMPLOYEE_DETAILS",
                column: "ID");
        }
    }
}

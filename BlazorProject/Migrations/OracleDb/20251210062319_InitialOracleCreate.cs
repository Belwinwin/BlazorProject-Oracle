using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorProject.Migrations.OracleDb
{
    /// <inheritdoc />
    public partial class InitialOracleCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EMPLOYEES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NAME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    role = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PhoneNumber = table.Column<long>(type: "NUMBER(19)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEES", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMPLOYEES");
        }
    }
}

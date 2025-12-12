using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorProject.Migrations.OracleDbContext3Migrations
{
    /// <inheritdoc />
    public partial class CreateUserDatabaseAccessTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USERDATABASEACCESS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    USERID = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DATABASENAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    HASACCESS = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    CREATEDAT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERDATABASEACCESS", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USERDATABASEACCESS");
        }
    }
}

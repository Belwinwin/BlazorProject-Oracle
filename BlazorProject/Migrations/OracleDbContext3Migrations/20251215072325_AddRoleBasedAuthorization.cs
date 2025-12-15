using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorProject.Migrations.OracleDbContext3Migrations
{
    /// <inheritdoc />
    public partial class AddRoleBasedAuthorization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NAME = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    CREATEDAT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USERROLES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    USERID = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ROLEID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ASSIGNEDAT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERROLES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USERROLES_ROLES_ROLEID",
                        column: x => x.ROLEID,
                        principalTable: "ROLES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ROLES",
                columns: new[] { "ID", "CREATEDAT", "DESCRIPTION", "NAME" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 15, 7, 23, 24, 267, DateTimeKind.Utc).AddTicks(8210), "Full system access", "Admin" },
                    { 2, new DateTime(2025, 12, 15, 7, 23, 24, 267, DateTimeKind.Utc).AddTicks(9784), "Management level access", "Manager" },
                    { 3, new DateTime(2025, 12, 15, 7, 23, 24, 267, DateTimeKind.Utc).AddTicks(9789), "Standard user access", "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_USERROLES_ROLEID",
                table: "USERROLES",
                column: "ROLEID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USERROLES");

            migrationBuilder.DropTable(
                name: "ROLES");
        }
    }
}

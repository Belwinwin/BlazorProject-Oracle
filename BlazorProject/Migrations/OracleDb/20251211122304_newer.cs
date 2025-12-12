using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorProject.Migrations.OracleDb
{
    /// <inheritdoc />
    public partial class newer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ASPNET_ROLE_CLAIMS");

            migrationBuilder.DropTable(
                name: "ASPNET_ROLES");

            migrationBuilder.DropTable(
                name: "ASPNET_USER_CLAIMS");

            migrationBuilder.DropTable(
                name: "ASPNET_USER_LOGINS");

            migrationBuilder.DropTable(
                name: "ASPNET_USER_ROLES");

            migrationBuilder.DropTable(
                name: "ASPNET_USER_TOKENS");

            migrationBuilder.DropTable(
                name: "ASPNET_USERS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EMPLOYEES",
                table: "EMPLOYEES");

            migrationBuilder.RenameTable(
                name: "EMPLOYEES",
                newName: "DETAILS");

            migrationBuilder.AlterColumn<string>(
                name: "ROLE",
                table: "DETAILS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "DETAILS",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "DETAILS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DETAILS",
                table: "DETAILS",
                column: "ID");

            migrationBuilder.InsertData(
                table: "DETAILS",
                columns: new[] { "ID", "NAME", "PHONENUMBER", "EMAIL", "ROLE" },
                values: new object[,]
                {
                    { 1, "John Smith", null, null, null },
                    { 2, "Sarah Johnson", null, null, null },
                    { 3, "Michael Brown", null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DETAILS",
                table: "DETAILS");

            migrationBuilder.DeleteData(
                table: "DETAILS",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DETAILS",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DETAILS",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "DETAILS",
                newName: "EMPLOYEES");

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
                name: "NAME",
                table: "EMPLOYEES",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "EMPLOYEES",
                type: "NVARCHAR2(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EMPLOYEES",
                table: "EMPLOYEES",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "ASPNET_ROLE_CLAIMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ClaimType = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true),
                    ClaimValue = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true),
                    RoleId = table.Column<string>(type: "NVARCHAR2(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASPNET_ROLE_CLAIMS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ASPNET_ROLES",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", maxLength: 450, nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true),
                    Name = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASPNET_ROLES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ASPNET_USER_CLAIMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ClaimType = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true),
                    ClaimValue = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true),
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASPNET_USER_CLAIMS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ASPNET_USER_LOGINS",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "NVARCHAR2(450)", maxLength: 450, nullable: false),
                    ProviderKey = table.Column<string>(type: "NVARCHAR2(450)", maxLength: 450, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true),
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASPNET_USER_LOGINS", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "ASPNET_USER_ROLES",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", maxLength: 450, nullable: false),
                    RoleId = table.Column<string>(type: "NVARCHAR2(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASPNET_USER_ROLES", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "ASPNET_USER_TOKENS",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", maxLength: 450, nullable: false),
                    LoginProvider = table.Column<string>(type: "NVARCHAR2(450)", maxLength: 450, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(450)", maxLength: 450, nullable: false),
                    Value = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASPNET_USER_TOKENS", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "ASPNET_USERS",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", maxLength: 450, nullable: false),
                    AccessFailedCount = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LockoutEnabled = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PhoneNumberConfirmed = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SecurityStamp = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true),
                    TwoFactorEnabled = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UserName = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASPNET_USERS", x => x.Id);
                });
        }
    }
}

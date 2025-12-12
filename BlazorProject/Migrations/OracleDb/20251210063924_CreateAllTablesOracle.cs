using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorProject.Migrations.OracleDb
{
    /// <inheritdoc />
    public partial class CreateAllTablesOracle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ASPNET_ROLE_CLAIMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    RoleId = table.Column<string>(type: "NVARCHAR2(450)", maxLength: 450, nullable: true),
                    ClaimType = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true),
                    ClaimValue = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true)
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
                    Name = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true)
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
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", maxLength: 450, nullable: true),
                    ClaimType = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true),
                    ClaimValue = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true)
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
                    UserName = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PasswordHash = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true),
                    SecurityStamp = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PhoneNumberConfirmed = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TwoFactorEnabled = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    LockoutEnabled = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASPNET_USERS", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTBlog.Infrastructure.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class addRefreshTokenToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiry",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "430278aa-03cc-4626-a61a-6087c3413375",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "RefreshTokenExpiry", "SecurityStamp" },
                values: new object[] { "f6a762cb-f0fb-4189-ab25-d2d3da461abb", "AQAAAAIAAYagAAAAEI3/neNW0ayS1cSd+U7nCgInJ9Q6DQa59j0ZdUI00IRhHru4XckC5Gy2WVifwqIyAA==", null, null, "54e2c1f0-817c-4ae8-bc4f-4d4364a675bf" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiry",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "430278aa-03cc-4626-a61a-6087c3413375",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8bd75f0b-dfc7-4f24-a043-c2e832122c31", "AQAAAAIAAYagAAAAEL1lVQqwlQGR5IRX0H8MAl3bP9eX4Ox2U+sVJAZMYdlnb+APcYhxS+ZoTHOM7VzIuA==", "62b04537-1800-46ca-b980-8abd5eea6d44" });
        }
    }
}

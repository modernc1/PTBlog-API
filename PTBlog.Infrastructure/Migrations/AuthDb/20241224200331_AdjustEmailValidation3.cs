using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTBlog.Infrastructure.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class AdjustEmailValidation3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "430278aa-03cc-4626-a61a-6087c3413375",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8bd75f0b-dfc7-4f24-a043-c2e832122c31", "AQAAAAIAAYagAAAAEL1lVQqwlQGR5IRX0H8MAl3bP9eX4Ox2U+sVJAZMYdlnb+APcYhxS+ZoTHOM7VzIuA==", "62b04537-1800-46ca-b980-8abd5eea6d44" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "430278aa-03cc-4626-a61a-6087c3413375",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83254864-fcf9-4ef5-8744-e3090d7c1a86", "AQAAAAIAAYagAAAAEBxMkHHGOhUWnNl3G4k0I85uDFUplcOdi6eGjKNJomwJH1ElRbPQQuRQu9Bq6QQ5Vg==", "9afa5332-b379-4a58-bd95-f8f0f2d5d8f5" });
        }
    }
}

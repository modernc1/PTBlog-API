using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTBlog.Infrastructure.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class AdjustEmailValidation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "430278aa-03cc-4626-a61a-6087c3413375",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83254864-fcf9-4ef5-8744-e3090d7c1a86", "AQAAAAIAAYagAAAAEBxMkHHGOhUWnNl3G4k0I85uDFUplcOdi6eGjKNJomwJH1ElRbPQQuRQu9Bq6QQ5Vg==", "9afa5332-b379-4a58-bd95-f8f0f2d5d8f5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "430278aa-03cc-4626-a61a-6087c3413375",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35ffd018-7ac7-49eb-8bc9-f3207e352f86", "AQAAAAIAAYagAAAAEFRNqeAGeLUYmSXebdoqIj4p9rSCKZSw4ZuF3TEE+mn6bMy2qcAl2Ix/h+k6vZRxrw==", "60e0ef64-ecc6-4305-ab55-0fd1e3cc1a74" });
        }
    }
}

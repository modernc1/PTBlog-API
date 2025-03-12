using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTBlog.Infrastructure.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class AdjustEmailValidation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "430278aa-03cc-4626-a61a-6087c3413375",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35ffd018-7ac7-49eb-8bc9-f3207e352f86", "AQAAAAIAAYagAAAAEFRNqeAGeLUYmSXebdoqIj4p9rSCKZSw4ZuF3TEE+mn6bMy2qcAl2Ix/h+k6vZRxrw==", "60e0ef64-ecc6-4305-ab55-0fd1e3cc1a74" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "430278aa-03cc-4626-a61a-6087c3413375",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fa446ee-e853-4a00-ba8c-f8f44566a3a7", "AQAAAAIAAYagAAAAEHuylc8KLXA0UbyAogF/kx66lH2bin+e6iQm98+OxtVLW9UdEHtUOLF5Flu3bRkUlw==", "7a4e4683-f87d-40f8-accb-f38bc29f161d" });
        }
    }
}

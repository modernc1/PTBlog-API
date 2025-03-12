using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTBlog.Infrastructure.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class EmailValidation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "430278aa-03cc-4626-a61a-6087c3413375",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fa446ee-e853-4a00-ba8c-f8f44566a3a7", "AQAAAAIAAYagAAAAEHuylc8KLXA0UbyAogF/kx66lH2bin+e6iQm98+OxtVLW9UdEHtUOLF5Flu3bRkUlw==", "7a4e4683-f87d-40f8-accb-f38bc29f161d" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "430278aa-03cc-4626-a61a-6087c3413375",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f69a3e0-5368-478c-b3d2-3a9a24a8f3ef", "AQAAAAIAAYagAAAAEIDt5v+EafRUUX1Lv3NK8VF5KFMgpuraAHkcA3iHyJAGgcKH3ML31IZ4HI18SVNdHg==", "d5ae102e-29bb-4752-9a0a-35e8b4eda726" });
        }
    }
}

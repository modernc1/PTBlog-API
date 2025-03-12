using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTBlog.Infrastructure.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class SeedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "430278aa-03cc-4626-a61a-6087c3413375", 0, "2f69a3e0-5368-478c-b3d2-3a9a24a8f3ef", "Admin@admin.com", false, "Admin", "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEIDt5v+EafRUUX1Lv3NK8VF5KFMgpuraAHkcA3iHyJAGgcKH3ML31IZ4HI18SVNdHg==", null, false, "d5ae102e-29bb-4752-9a0a-35e8b4eda726", false, "Admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8b31a5cd-b50b-4ff0-84e1-356823cd3a82", "430278aa-03cc-4626-a61a-6087c3413375" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8b31a5cd-b50b-4ff0-84e1-356823cd3a82", "430278aa-03cc-4626-a61a-6087c3413375" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "430278aa-03cc-4626-a61a-6087c3413375");
        }
    }
}

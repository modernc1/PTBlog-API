using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PTBlog.Domain.Entities;


namespace PTBlog.Infrastructure.Data
{
    class AuthDbContext(DbContextOptions<AuthDbContext> options) : IdentityDbContext<User>(options)
    {

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Validate Email
            builder.Entity<User>(entity =>
            {
                // Make Email required

                // Ensure Email is unique
                entity.HasIndex(u => u.Email).IsUnique();

                // Configure NormalizedEmail for case-insensitive lookups
                entity.Property(u => u.NormalizedEmail)
                    .IsRequired()
                    .HasMaxLength(256);

            });



            //Create roles

            var ReaderRoleId = "00885051-92a4-42ad-bc99-36fed08e3b3b";
            var WriterRoleId = "e37309d9-ca51-4f37-8803-5676c8fc8344";
            var AdminRoleId = "8b31a5cd-b50b-4ff0-84e1-356823cd3a82";
            var roles = new List<IdentityRole>()
            {
                new IdentityRole() {Id= ReaderRoleId, Name= "Reader", NormalizedName= "Reader".ToUpper(), ConcurrencyStamp= ReaderRoleId},
                new IdentityRole() {Id= WriterRoleId, Name= "Writer", NormalizedName= "Writer".ToUpper(), ConcurrencyStamp= WriterRoleId},
                new IdentityRole() {Id= AdminRoleId, Name= "Admin", NormalizedName= "Admin".ToUpper(), ConcurrencyStamp= AdminRoleId},
            };

            ////seed 
            builder.Entity<IdentityRole>().HasData(roles);

            //////////////////////////////////////////Seed User Must Be In Migration After IdentityRole Seed Migration to not throgh FK_Constrain Error
            //Create Admin User
            var AdminUserId = "430278aa-03cc-4626-a61a-6087c3413375";
            var admin = new User()
            {
                Id = AdminUserId,
                UserName = "Admin@admin.com",
                NormalizedUserName = "Admin@admin.com".ToUpper(),
                Email = "Admin@admin.com",
                NormalizedEmail = "Admin@admin.com".ToUpper(),
                FirstName = "Admin",
                LastName = "Admin"
            };

            //create Password and seed admin
            admin.PasswordHash = new PasswordHasher<User>().HashPassword(admin, "Admin@123");


            builder.Entity<User>().HasData(admin);

            //assign admin Role
            var AdminRole = new IdentityUserRole<string>()
            {
                RoleId = AdminRoleId,
                UserId = AdminUserId,
            };

            builder.Entity<IdentityUserRole<string>>().HasData(AdminRole);


            //must inject it in program.cs


        }
    }
}

using Blog.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Dal.Mappings
{
    public class UserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            // Primary key
            builder.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

            // Maps to the AspNetUsers table
            builder.ToTable("Users");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.UserName).HasMaxLength(256);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            builder.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            builder.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
            var superadmin = new AppUser
            {
                Id = new Guid("643B7BCC-E8AB-4321-A7EB-0E3D3D88795B"),
                UserName = "ozpinar09@gmail.com",
                NormalizedEmail = "OZPINAR09@GMAIL.COM",
                Email = "ozpinar09@gmail.com",
                PhoneNumber = "05442164492",
                FirstName = "Ozkan",
                LastName = "Ozpinar",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ImageId = Guid.Parse("184BAF77-DE82-4DA0-8D25-7CC577FB58C1"),
            };
            superadmin.PasswordHash = CreatePasswordHash(superadmin, "123456");
            var admin = new AppUser
            {
                Id = Guid.Parse("3B60065E-88F1-4A31-9F2B-5E40306DBD06"),
                UserName = "ozpinar09@uni-yaz.com",
                NormalizedEmail = "OZPINAR09@UNI-YAZ.COM",
                Email = "ozpinar09@uni-yaz.com",
                PhoneNumber = "05442164482",
                FirstName = "Admin",
                LastName = "User",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ImageId = Guid.Parse("30ACD681-F1DF-42D0-8238-9F2F7DF4CC79"),

            };
            admin.PasswordHash = CreatePasswordHash(admin, "123456");
            builder.HasData(superadmin, admin);
        }

        private string CreatePasswordHash(AppUser user, string password)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(user, password);

        }
    }
}


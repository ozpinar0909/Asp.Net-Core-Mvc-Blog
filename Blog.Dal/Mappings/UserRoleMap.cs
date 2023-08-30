using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Dal.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("UserRoles");
            builder.HasData(new AppUserRole
            {
                UserId = new Guid("643B7BCC-E8AB-4321-A7EB-0E3D3D88795B"),
                RoleId = new Guid("87DCAC24-7E70-453D-AD59-BA3A873B31D5"),

            },
            new AppUserRole
            {
                UserId = Guid.Parse("3B60065E-88F1-4A31-9F2B-5E40306DBD06"),
                RoleId = new Guid("7DB648B7-7CCE-420B-9E22-FAFC33126B43"),
            });
        }
    }
}

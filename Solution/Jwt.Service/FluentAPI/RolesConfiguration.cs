using Jwt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBContext.FluentAPI
{
    public class RolesConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasMany(b => b.Users)
                .WithMany(i => i.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    j => j.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    j => j.HasOne<Role>().WithMany().HasForeignKey("RoleId"));

            builder
                .HasMany(b => b.Methods)
                .WithMany(i => i.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "RoleMethod",
                    j => j.HasOne<Method>().WithMany().HasForeignKey("MethodId"),
                    j => j.HasOne<Role>().WithMany().HasForeignKey("RoleId"));

            builder.HasQueryFilter(m => !m.FechaBaja.HasValue);

            builder.Property(b => b.Name).IsRequired();
        }
    }
}

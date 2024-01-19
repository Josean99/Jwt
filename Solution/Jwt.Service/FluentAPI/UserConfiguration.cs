using Jwt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBContext.FluentAPI
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasMany(b => b.Roles)
                .WithMany(i => i.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    j => j.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                    j => j.HasOne<User>().WithMany().HasForeignKey("UserId"));

            builder.Property(b => b.Password).IsRequired();
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.Surname).IsRequired();

        }
    }
}

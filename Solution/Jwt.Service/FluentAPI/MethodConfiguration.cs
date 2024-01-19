using Jwt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBContext.FluentAPI
{
    public class MethodConfiguration : IEntityTypeConfiguration<Method>
    {
        public void Configure(EntityTypeBuilder<Method> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasMany(b => b.Roles)
                .WithMany(i => i.Methods)
                .UsingEntity<Dictionary<string, object>>(
                    "RoleMethod",
                    j => j.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                    j => j.HasOne<Method>().WithMany().HasForeignKey("MethodId"));

            builder
                .HasOne(b => b.Microservice)
                .WithMany(i => i.Methods)
                .HasForeignKey(i=>i.IdMicroservice);

            builder.Property(b => b.Verb).IsRequired();
            builder.Property(b => b.Path).IsRequired();
            builder.Property(b => b.IdMicroservice).IsRequired();
        }
    }
}

using Jwt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBContext.FluentAPI
{
    public class MicroserviceConfiguration : IEntityTypeConfiguration<Microservice>
    {
        public void Configure(EntityTypeBuilder<Microservice> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasMany(b => b.Methods)
                .WithOne(i => i.Microservice)
                .HasForeignKey(i=>i.IdMicroservice);

            builder.Property(b => b.Name).IsRequired();
        }
    }
}

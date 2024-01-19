using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Jwt.Models;
using DBContext.Base;
using Microsoft.EntityFrameworkCore.Storage;
using DBContext.FluentAPI;

namespace DBContext
{
    public class JwtContext : DbContext, IUnitOfWork
    {
        public JwtContext(DbContextOptions<JwtContext> options)
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public void Save()
        {
            this.SaveChanges();
        }

        public IDbContextTransaction GetTransaction()
        {
            return this.Database.BeginTransaction();
        }

        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Role> Roles { get; set; } = default!;
        public DbSet<Method> Methods { get; set; } = default!;
        public DbSet<Microservice> Microservices { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new MethodConfiguration());

            modelBuilder.ApplyConfiguration(new MicroserviceConfiguration());

            modelBuilder.ApplyConfiguration(new RolesConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());            

        }
    }
}
    

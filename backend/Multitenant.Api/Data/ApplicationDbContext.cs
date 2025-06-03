using Microsoft.EntityFrameworkCore;
using Multitenant.Api.Models;

namespace Multitenant.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>().ToTable("Tenants");
            base.OnModelCreating(modelBuilder);
        }
    }
}

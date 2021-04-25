using BA.Caixa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BA.Caixa.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Notas> Notas { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}

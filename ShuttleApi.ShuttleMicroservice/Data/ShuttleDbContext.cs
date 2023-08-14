using Microsoft.EntityFrameworkCore;
using ShuttleApi.ShuttleMicroservice.Models;

namespace ShuttleApi.ShuttleMicroservice.Data
{
    public class ShuttleDbContext : DbContext
    {
        public ShuttleDbContext(DbContextOptions<ShuttleDbContext> options) : base(options)
        {
            
        }

        public DbSet<Shuttle> Shuttles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Остальные конфигурации моделей...

            base.OnModelCreating(modelBuilder);
        }
    }
}

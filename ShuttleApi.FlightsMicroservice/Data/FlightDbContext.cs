using Microsoft.EntityFrameworkCore;
using ShuttleApi.FlightsMicroservice.Models;

namespace ShuttleApi.FlightsMicroservice.Data
{
    public class FlightDbContext : DbContext
    {
        public FlightDbContext(DbContextOptions<FlightDbContext> options) : base(options)
        {
            
        }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Planet> Planets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Остальные конфигурации моделей...

            base.OnModelCreating(modelBuilder);
        }
    }
}

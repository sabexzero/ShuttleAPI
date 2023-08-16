using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShuttleApi.PilotMicroservice.Models;

namespace ShuttleApi.PilotMicroservice.Data
{
    public class PilotDbContext : IdentityDbContext<Pilot, IdentityRole, string>
    {
        public PilotDbContext(DbContextOptions<PilotDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Остальные конфигурации моделей...

            base.OnModelCreating(modelBuilder);
        }
    }
}

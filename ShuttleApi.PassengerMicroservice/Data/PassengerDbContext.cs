using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShuttleApi.PassengerMicroservice.Models;

namespace ShuttleApi.PassengerMicroservice.Data
{
    public class PassengerDbContext : IdentityDbContext<Passenger, IdentityRole, string>
    {
        public PassengerDbContext(DbContextOptions<PassengerDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Passenger>().Ignore(s => s.UserName);

            base.OnModelCreating(modelBuilder);
        }
    }
}

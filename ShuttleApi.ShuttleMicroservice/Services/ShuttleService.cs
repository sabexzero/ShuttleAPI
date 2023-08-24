using Microsoft.EntityFrameworkCore;
using ShuttleApi.ShuttleMicroservice.Common.Utilities;
using ShuttleApi.ShuttleMicroservice.Data;
using ShuttleApi.ShuttleMicroservice.Models;
using ShuttleApi.ShuttleMicroservice.Services.Contracts;

namespace ShuttleApi.ShuttleMicroservice.Services
{
    public class ShuttleService : IShuttleService
    {
        private readonly ShuttleDbContext _context;
        public ShuttleService(ShuttleDbContext context)
        {
             _context = context;
        }

        public async Task CreateShuttle(string title, int passengerLimit, int pilotsLimit, int capacity, int consumption, int averageSpeed, FuelType fuelType, CancellationToken cancellationToken)
        {
            var checkForTitle = await GetShuttleByTitle(title);
            if (checkForTitle == null)
                throw new InvalidOperationException();
            var newShuttle = new Shuttle() 
            { 
                    Title = title, 
                    AverageSpeed = averageSpeed, 
                    FuelType = fuelType, 
                    FuelCapacity = capacity, 
                    FuelConsumption = consumption, 
                    PassengerLimit = passengerLimit, 
                    PilotsLimit = pilotsLimit, 
                    CreatedAt = DateTimeOffset.UtcNow, 
                    Id = Guid.NewGuid() 
            };
            await _context.AddAsync(newShuttle, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteShuttle(Guid id, CancellationToken cancellationToken)
        {
            var checkShuttle = await GetShuttleById(id, cancellationToken);
            if (checkShuttle == null)
                throw new InvalidOperationException();
            _context.Remove(checkShuttle);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Shuttle>> GetAllShuttles()
        {
            return await _context.Set<Shuttle>().ToListAsync();
        }

        public async Task<Shuttle> GetShuttleById(Guid id, CancellationToken cancellationToken)
        {
            var checkShuttle = await _context.Set<Shuttle>().FirstOrDefaultAsync(shuttle => shuttle.Id == id, cancellationToken);
            if(checkShuttle == null)
                throw new InvalidOperationException();
            return checkShuttle;
        }

        public async Task<Shuttle> GetShuttleByTitle(string title, CancellationToken cancellationToken)
        {
            var checkShuttle = await _context.Set<Shuttle>().FirstOrDefaultAsync(shuttle => shuttle.Title == title, cancellationToken);
            if(checkShuttle == null)
                throw new InvalidOperationException();
            return checkShuttle;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ShuttleApi.ShuttleMicroservice.Common.Exceptions.Shuttle;
using ShuttleApi.ShuttleMicroservice.Common.Utilities;
using ShuttleApi.ShuttleMicroservice.Data;
using ShuttleApi.ShuttleMicroservice.Models;
using ShuttleApi.ShuttleMicroservice.Services.Contracts;

using NLog;

namespace ShuttleApi.ShuttleMicroservice.Services
{
    public class ShuttleService : IShuttleService
    {
        private readonly ShuttleDbContext _context;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public ShuttleService(ShuttleDbContext context)
        {
            _context = context;
        }

        public async Task CreateShuttle(string title, int passengerLimit, int pilotsLimit, int capacity, int consumption, int averageSpeed, FuelType fuelType, CancellationToken cancellationToken)
        {
            var checkForTitle = await GetShuttleByTitle(title, cancellationToken);
            if (checkForTitle == null)
            {
                _logger.Error($"failed to create shuttle enitity, because entity with ({title}) as title alredy exists in db");
                throw new ShuttleAlreadyExistException();
            }
            var newShuttle = new Shuttle()
            {
                Title = title,
                AverageSpeed = averageSpeed,
                FuelType = fuelType,
                FuelTankCapacity = capacity,
                FuelConsumption = consumption,
                PassengerLimit = passengerLimit,
                PilotsLimit = pilotsLimit,
                CreatedAt = DateTimeOffset.UtcNow,
                Id = Guid.NewGuid()
            };
            try
            {
                await _context.AddAsync(newShuttle, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                _logger.Info($"Creating shuttle with Id - {newShuttle.Id} and title - {newShuttle.Title}");

            }
            catch (Exception)
            {
                _logger.Error($"failed to create shuttle enitity, for some unknown reason");
                throw new CreateErrorException();
            }
        }

        public async Task DeleteShuttle(Guid id, CancellationToken cancellationToken)
        {
            var checkShuttle = await GetShuttleById(id, cancellationToken);
            if (checkShuttle == null)
            {
                _logger.Error($"failed to delete shuttle enitity, because it doesnt exists in db");
                throw new ShuttleNotFoundException();
            }
            try
            {
                _context.Remove(checkShuttle);
                await _context.SaveChangesAsync(cancellationToken);
                _logger.Info($"Success deleting shuttle entity with Id - {id} ");
            }
            catch (Exception)
            {
                _logger.Error("failed to delete shuttle enitity, for some unknown reason");
                throw new DeleteErrorException();
            }
        }

        public async Task<IEnumerable<Shuttle>> GetAllShuttles(CancellationToken cancellationToken)
        {
            _logger.Error("a list of all spaceships was called up");
            return await _context.Set<Shuttle>().ToListAsync(cancellationToken);
        }

        public async Task<Shuttle> GetShuttleById(Guid id, CancellationToken cancellationToken)
        {
            var checkShuttle = await _context.Set<Shuttle>().FirstOrDefaultAsync(shuttle => shuttle.Id == id, cancellationToken);
            if (checkShuttle == null)
            {
                _logger.Error($"failed to get shuttle enitity by id, because it doesnt exists in db");
                throw new ShuttleNotFoundException();
            }
            return checkShuttle;
        }

        public async Task<Shuttle> GetShuttleByTitle(string title, CancellationToken cancellationToken)
        {
            var checkShuttle = await _context.Set<Shuttle>().FirstOrDefaultAsync(shuttle => shuttle.Title == title, cancellationToken);
            if (checkShuttle == null)
            {
                _logger.Error($"failed to get shuttle enitity by title, because it doesnt exists in db");
                throw new ShuttleNotFoundException();
            }
            return checkShuttle;
        }
    }
}

using ShuttleApi.ShuttleMicroservice.Common.Utilities;
using ShuttleApi.ShuttleMicroservice.Models;
using System.Numerics;

namespace ShuttleApi.ShuttleMicroservice.Services.Contracts
{
    public interface IShuttleService
    {
        Task CreateShuttle(string title, int passengerLimit, int pilotsLimit, int capacity, int consumption, int averageSpeed, FuelType fuelType, CancellationToken cancellationToken);
        Task DeleteShuttle(Guid id, CancellationToken cancellationToken);
        Task<Shuttle> GetShuttleById(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Shuttle>> GetAllShuttles(CancellationToken cancellationToken);
        Task<Shuttle> GetShuttleByTitle(string title, CancellationToken cancellationToken);
    }
}

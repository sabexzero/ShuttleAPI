using ShuttleApi.ShuttleMicroservice.Common.Utilities;
using ShuttleApi.ShuttleMicroservice.Data.DTOs;
using ShuttleApi.ShuttleMicroservice.Models;
using System.Numerics;

namespace ShuttleApi.ShuttleMicroservice.Services.Contracts
{
    public interface IShuttleService
    {
        Task CreateShuttle(ShuttleDTO shuttleDto, CancellationToken cancellationToken);
        Task DeleteShuttle(string id, CancellationToken cancellationToken);
        Task<ShuttleDTO> GetShuttleById(string id, CancellationToken cancellationToken);
        Task<IEnumerable<ShuttleDTO>> GetAllShuttles(CancellationToken cancellationToken);
        Task<ShuttleDTO> GetShuttleByTitle(string title, CancellationToken cancellationToken);
    }
}

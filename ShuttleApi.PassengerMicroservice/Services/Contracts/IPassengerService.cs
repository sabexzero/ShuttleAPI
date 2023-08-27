using ShuttleApi.PassengerMicroservice.Data.DTOs;
using ShuttleApi.PassengerMicroservice.Models;
using System.Numerics;

namespace ShuttleApi.PassengerMicroservice.Services.Contracts
{
    public interface IPassengerService
    {
        Task<Passenger> CreatePassenger(PassengerDTO passengerDTO, string password, CancellationToken cancellationToken);
        Task DeletePassenger(string id, CancellationToken cancellationToken);
        Task<IEnumerable<Passenger>> GetAllPassengers(CancellationToken cancellationToken);
        Task<Passenger> GetPassengerById(string id, CancellationToken cancellationToken);
        Task<Passenger> GetPassengerByName(string username, CancellationToken cancellationToken);
    }
}

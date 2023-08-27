using ShuttleApi.PilotMicroservice.Data.DTOs;
using ShuttleApi.PilotMicroservice.Models;
using System.Numerics;

namespace ShuttleApi.PilotMicroservice.Services.Contracts
{
    public interface IPilotService
    {
        Task CreatePilot(PilotDTO pilotDTO, string password);
        Task DeletePilot(string id);
        Task<IEnumerable<PilotDTO>> GetAllPilots();
        Task<PilotDTO> GetPilotById(string id);
    }
}

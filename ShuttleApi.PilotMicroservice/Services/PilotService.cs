using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NLog;
using ShuttleApi.PilotMicroservice.Data.DTOs;
using ShuttleApi.PilotMicroservice.Models;
using ShuttleApi.PilotMicroservice.Services.Contracts;

namespace ShuttleApi.PilotMicroservice.Services
{
    public class PilotService : IPilotService
    {
        private readonly IMapper _mapper;
        private readonly Logger _logger;
        private readonly UserManager<Pilot> _pilotManager;

        public PilotService(IMapper mapper, UserManager<Pilot> pilotManager)
        {
            _mapper = mapper;
            _pilotManager = pilotManager;
            _logger = LogManager.GetCurrentClassLogger();
        }
        public async Task CreatePilot(PilotDTO pilotDTO, string password)
        {
            var passwordValidator = new PasswordValidator<Pilot>();
            var newPilot = _mapper.Map<Pilot>(pilotDTO);
            var checkPilot = await _pilotManager.FindByIdAsync(newPilot.Id);
            if (checkPilot != null)
            {
                _logger.Error("Failed to create pilot, he is already exist in db");
                throw new InvalidOperationException();
            }
            var validateResult = await passwordValidator.ValidateAsync(_pilotManager, newPilot, password);
            if (!validateResult.Succeeded)
                throw new InvalidOperationException();
            try
            {
                await _pilotManager.CreateAsync(newPilot, password);
                _logger.Info($"Pilot {newPilot.Surname} {newPilot.Name} with Id {newPilot.Id} was created!");
            }
            catch (Exception)
            {
                _logger.Error("failed to create pilot, for some unknown reason");
                throw new InvalidOperationException();
            }
        }

        public async Task DeletePilot(string id)
        {
            var checkPilot = await _pilotManager.FindByIdAsync(id);
            if (checkPilot == null)
                throw new InvalidOperationException();
            try
            {
                await _pilotManager.DeleteAsync(checkPilot);
            }
            catch (Exception)
            {

                throw new InvalidOperationException();
            }
        }

        public async Task<IEnumerable<PilotDTO>> GetAllPilots()
        {
            return await _pilotManager.Users.Select(s => _mapper.Map<PilotDTO>(s)).ToListAsync();

        }

        public async Task<PilotDTO> GetPilotById(string id)
        {
            return _mapper.Map<PilotDTO>(await _pilotManager.FindByIdAsync(id));
        }
    }
}

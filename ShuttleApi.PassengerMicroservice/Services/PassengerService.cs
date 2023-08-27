using Microsoft.AspNetCore.Identity;
using ShuttleApi.PassengerMicroservice.Data.DTOs;
using ShuttleApi.PassengerMicroservice.Models;
using ShuttleApi.PassengerMicroservice.Services.Contracts;

using AutoMapper;
using NLog;
using Microsoft.EntityFrameworkCore;

namespace ShuttleApi.PassengerMicroservice.Services
{
/*  UserManagerобрабатывает отмену внутри себя и получает токен отмены от HttpContext.RequestAborted.
      Таким образом, вам не нужно передавать токен отмены, и поэтому методы его не принимают.*/

    public class PassengerService : IPassengerService
    {
        private readonly UserManager<Passenger> _passengerManager;
        private readonly IMapper _mapper;
        private readonly Logger _logger;
        public PassengerService(Mapper mapper, UserManager<Passenger> passengerManager)
        {
            _passengerManager = passengerManager;
            _mapper = mapper;
            _logger = LogManager.GetCurrentClassLogger();
        }
        public async Task CreatePassenger(PassengerDTO passengerDTO, string password)
        {
            var passwordValidator = new PasswordValidator<Passenger>();
            var newPassenger = _mapper.Map<Passenger>(passengerDTO);
            var checkPassenger = await _passengerManager.FindByIdAsync(newPassenger.Id);
            if (checkPassenger != null)
            {
                _logger.Error("Failed to create passenger, he is already exist in db");
                throw new InvalidOperationException();
            }
            var validateResult = await passwordValidator.ValidateAsync(_passengerManager, newPassenger, password);
            if (!validateResult.Succeeded)
                throw new InvalidOperationException();
            try
            {
                await _passengerManager.CreateAsync(newPassenger, password);
                _logger.Info($"Passenger {newPassenger.Surname} {newPassenger.Name} with Id {newPassenger.Id} was created!");
            }
            catch(Exception)
            {
                _logger.Error("failed to create passenger, for some unknown reason");
                throw new InvalidOperationException();
            }  
        }

        public async Task DeletePassenger(string id)
        {
            var checkPassenger = await _passengerManager.FindByIdAsync(id);
            if (checkPassenger == null)
                throw new InvalidOperationException();
            try
            {
                await _passengerManager.DeleteAsync(checkPassenger);
            }
            catch (Exception)
            {

                throw new InvalidOperationException();
            }
        }

        public async Task<IEnumerable<Passenger>> GetAllPassengers()
        {
            return await _passengerManager.Users.ToListAsync();
        }

        public async Task<Passenger> GetPassengerById(string id)
        {
            return await _passengerManager.FindByIdAsync(id);
        }
    }
}

﻿using ShuttleApi.PassengerMicroservice.Data.DTOs;
using ShuttleApi.PassengerMicroservice.Models;
using System.Numerics;

namespace ShuttleApi.PassengerMicroservice.Services.Contracts
{
    public interface IPassengerService
    {
        Task CreatePassenger(PassengerDTO passengerDTO, string password);
        Task DeletePassenger(string id);
        Task<IEnumerable<Passenger>> GetAllPassengers();
        Task<Passenger> GetPassengerById(string id);
    }
}

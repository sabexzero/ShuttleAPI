using AutoMapper;
using ShuttleApi.PassengerMicroservice.Data.DTOs;
using ShuttleApi.PassengerMicroservice.Models;

namespace ShuttleApi.ShuttleMicroservice.Common.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PassengerDTO, Passenger>();
            CreateMap<Passenger, PassengerDTO>();
        }
    }
}

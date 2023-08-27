using AutoMapper;
using ShuttleApi.ShuttleMicroservice.Data.DTOs;
using ShuttleApi.ShuttleMicroservice.Models;

namespace ShuttleApi.ShuttleMicroservice.Common.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ShuttleDTO, Shuttle>();
            CreateMap<Shuttle, ShuttleDTO>();
        }
    }
}

using ShuttleApi.ShuttleMicroservice.Models;

namespace ShuttleApi.ShuttleMicroservice.Data.DTOs
{
    public class ShuttleDTO
    {
        public string? Id { get; set; } 
        public string Title { get; set; }
        public int PassengerLimit { get; set; }
        public int PilotsLimit { get; set; }
        public int FuelTankCapacity { get; set; }
        public int FuelConsumption { get; set; }
        public int AverageSpeed { get; set; }
        public FuelType FuelType { get; set; }
    }
}

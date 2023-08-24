using ShuttleApi.ShuttleMicroservice.Common.Utilities;

namespace ShuttleApi.ShuttleMicroservice.Models
{
    public class Shuttle
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public int PassengerLimit { get; set; }
        public int PilotsLimit { get; set; }
        public int FuelTankCapacity { get; set; } //объем
        public int FuelConsumption { get; set; } //расход топлива
        public int AverageSpeed { get; set; } // тут от 10кк км/ч до 100кк км/ч
        public FuelType FuelType { get; set; }

    }
}


namespace ShuttleApi.ShuttleMicroservice.Models
{
    public class Shuttle
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public int PassengerLimit { get; set; }
        public int PilotsLimit { get; set; }
        public int FuelTankCapacity { get; set; } //объем
        public int FuelConsumption { get; set; } //расход топлива
        public int AverageSpeed { get; set; } // тут от 10кк км/ч до 100кк км/ч
        public FuelType FuelType { get; set; }

    }
    public enum FuelType
    {
        Pepsi = 0, //один литр на 1кк км
        Coke = 1, //один литр на 100кк км
    }
}

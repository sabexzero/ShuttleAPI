
namespace ShuttleApi.FlightsMicroservice.Models
{
    public class Flight
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset DepartureTime { get; set; }
        public DateTimeOffset ArrivalTime { get; set; }
        public int PassengersMininimum { get; set; } //минимальное количество, чтобы полететь
        public string ShuttleId { get; set; }
        public string DepartureStationId { get; set; }
        public string ArrivalStationId { get; set; }
        public string PilotIds { get; set; } 
        public string PassengerId { get; set; }
        public int Price { get; set; }
        public FlightClass FlightClass { get; set; }
    }

    public enum FlightClass
    {
        Economy = 0,
        Comfort = 1,
        ComfortPlus = 2,
        Business = 3
    }
}

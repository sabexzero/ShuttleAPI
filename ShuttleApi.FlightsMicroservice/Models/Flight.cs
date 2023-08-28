
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
        public List<string> PilotIds { get; set; } = new List<string>();
        public List<string> PassengerIds { get; set; } = new List<string>();
        public FlightDifficulty FlightDifficulty { get; set; }
    }

    public enum FlightDifficulty
    {
        Simple = 0,          // Простой
        Moderate = 1,        // Умеренный
        Complex = 2,         // Сложный
        Daunting = 3         // Пугающий
    }

}

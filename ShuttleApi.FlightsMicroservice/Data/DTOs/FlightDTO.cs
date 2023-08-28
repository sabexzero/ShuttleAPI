using ShuttleApi.FlightsMicroservice.Models;

namespace ShuttleApi.FlightsMicroservice.Data.DTOs
{
    public class FlightDTO
    {
        public string? Id { get; set; }
        public DateTimeOffset? DepartureTime { get; set; }
        public DateTimeOffset? ArrivalTime { get; set; }
        public string ShuttleId { get; set; }
        public string DepartureStationId { get; set; }
        public string ArrivalStationId { get; set; }
        public List<string>? PilotIds { get; set; }
        public List<string>? PassengerIds { get; set; }
        public FlightDifficulty FlightDifficulty { get; set; }
    }
}

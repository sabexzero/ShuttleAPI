using ShuttleApi.FlightsMicroservice.Common.Utilities;

namespace ShuttleApi.FlightsMicroservice.Models
{
    public class Flight
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset DepartureTime { get; set; }
        public DateTimeOffset ArrivalTime { get; set; }
        public Guid ShuttleId { get; set; }
        public Guid DepartureStationId { get; set; }
        public Guid ArrivalStationId { get; set; }
        public List<Guid> PilotIds { get; set; }
        public List<Guid> PassengerIds { get; set; }
        public FlightDifficulty FlightDifficulty { get; set; }
    }

}

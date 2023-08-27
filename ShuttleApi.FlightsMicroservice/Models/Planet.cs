namespace ShuttleApi.FlightsMicroservice.Models
{
    public class Planet
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<Guid> StationIds { get; set; } = new List<Guid>();

    }
}

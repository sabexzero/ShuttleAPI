namespace ShuttleApi.FlightsMicroservice.Models
{
    public class Planet
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public List<string> StationIds { get; set; } = new List<string>();

    }
}

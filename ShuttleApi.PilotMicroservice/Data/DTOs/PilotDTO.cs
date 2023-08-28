using ShuttleApi.PilotMicroservice.Models;

namespace ShuttleApi.PilotMicroservice.Data.DTOs
{
    public class PilotDTO
    {
        public string? Id { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public int FlightsAmount { get; set; }
        public PilotRank Rank { get; set; }
    }
}

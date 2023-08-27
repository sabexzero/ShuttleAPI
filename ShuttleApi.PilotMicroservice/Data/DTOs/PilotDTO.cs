using ShuttleApi.PilotMicroservice.Common.Utilities;

namespace ShuttleApi.PilotMicroservice.Data.DTOs
{
    public class PilotDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public int FlightsAmount { get; set; }
        public PilotRank Rank { get; set; }
    }
}

using ShuttleApi.PassengerMicroservice.Models;

namespace ShuttleApi.PassengerMicroservice.Data.DTOs
{
    public class PassengerDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using ShuttleApi.PassengerMicroservice.Common.Utilities;
using System.ComponentModel.DataAnnotations;

namespace ShuttleApi.PassengerMicroservice.Models
{
    public class Passenger : IdentityUser
    {
        public DateTimeOffset CreatedAt { get; } = DateTimeOffset.UtcNow;
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public Uri? AvatarUrl { get; set; } = default;
        public long Balance { get; set; } = 0;
    }
    public enum Gender
    {
        Male = 1,
        Female = 2,
        NoMatter = 3
    }
}

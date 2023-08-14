using Microsoft.AspNetCore.Identity;
using ShuttleApi.PassengerMicroservice.Common.Utilities;
using System.ComponentModel.DataAnnotations;

namespace ShuttleApi.PassengerMicroservice.Models
{
    public class Passenger : IdentityUser
    {
        public DateTimeOffset? CreatedAt { get; } = DateTimeOffset.UtcNow;

        [Required(ErrorMessage = "Name field is required")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname field is required")]
        [StringLength(100)]
        public string Surname { get; set; }
        [Required]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "BirthDate field is required")]
        public DateOnly BirthDate { get; set; }
        public Uri? AvatarUrl { get; set; }
        public long Balance { get; set; } = 0;
    }
}

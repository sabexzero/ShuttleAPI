using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ShuttleApi.PilotMicroservice.Common.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ShuttleApi.PilotMicroservice.Models
{
    public class Pilot : IdentityUser
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
        public int FlightsAmount { get; set; }
        public PilotRank Rank { get; set; }
    }
    public enum PilotRank
    {
        StellarCadet = 0,
        CosmonautExplorer = 1,
        AstronautTraveler = 2,
        StarshipCaptain = 3
    }
    public enum Gender
    {
        Male = 1,
        Female = 2,
        NoMatter = 3
    }
}

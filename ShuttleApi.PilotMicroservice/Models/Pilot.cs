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
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public Uri? AvatarUrl { get; set; }
        public int FlightsAmount { get; set; }
        public PilotRank Rank { get; set; }
    }
}

using PeruTrekkings.API.Models.Domain;

namespace PeruTrekkings.API.Models.DTO.WalkDTOs
{
    public class AddWalkDTO
    {        
        public string Name { get; set; }
        public string Description { get; set; }

        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; }

        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }


    }
}

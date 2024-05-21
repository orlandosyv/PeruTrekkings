using PeruTrekkings.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace PeruTrekkings.API.Models.DTO.WalkDTOs
{
    public class AddWalkDTO
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Code has to be 100 char max")]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Code has to be 1000 char max")]
        public string Description { get; set; }

        [Required]
        [Range(0, 50)]
        public double LengthInKm { get; set; }

        //No validation
        public string? WalkImageUrl { get; set; }

        [Required]
        public Guid DifficultyId { get; set; }

        [Required]
        public Guid RegionId { get; set; }
    }
}

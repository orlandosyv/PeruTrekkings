using System.ComponentModel.DataAnnotations;

namespace PeruTrekkings.API.Models.DTO.RegionDTOs
{
    public class UpdateRegionDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has to be 3 char")]
        [MaxLength(3, ErrorMessage = "Code has to be 3 char")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage ="Name has to be 100 char max")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PeruTrekkings.API.Models.DTO
{
    public class ImageUpDto
    {
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
        //public string FileExtension { get; set; }
        //public long FileSizeInBytes { get; set; }
        //public string FilePath { get; set; }
    }
}

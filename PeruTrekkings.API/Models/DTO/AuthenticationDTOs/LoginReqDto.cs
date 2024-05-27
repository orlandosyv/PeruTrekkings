using System.ComponentModel.DataAnnotations;

namespace PeruTrekkings.API.Models.DTO.AuthenticationDTOs
{
    public class LoginReqDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

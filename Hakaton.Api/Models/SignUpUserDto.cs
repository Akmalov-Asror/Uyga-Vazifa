using System.ComponentModel.DataAnnotations;

namespace HakatonApi.Models
{
    public class SignUpUserDto
    {
        [Required]
        public string? UserName { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Required]
        public string? Password { get; set; }
        [Required]
        public string? ConfirmPassword { get; set; }

        public IFormFile? Avatar { get; set; }
    }
}
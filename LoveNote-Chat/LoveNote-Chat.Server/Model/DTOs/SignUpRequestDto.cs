using System.ComponentModel.DataAnnotations;

namespace Love_Note.UI.Server.Model.DTOs
{
    public class SignUpRequestDto
    {
        [Required]
        public string? FullName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        public string UserName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string? Gender { get; set; }
    }
}

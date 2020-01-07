using System.ComponentModel.DataAnnotations;

namespace TekENotions.API.DTOs
{
    public class UserForRegisterDTO
    {
        [Required]
        
        public string Username { get; set; }
        [Required]
        [StringLength( 8, MinimumLength = 4, ErrorMessage = "Password should be between 4-8 characters.")]
        public string Password { get; set; }
    }
}

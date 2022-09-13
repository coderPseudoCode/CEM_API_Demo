using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CEM_API.Data.DTOs
{
    public class AuthDTO
    {
        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        [DisplayName("Email, Phone or Username")]
        public string UserLogin { get; set; } = string.Empty;
    }
}

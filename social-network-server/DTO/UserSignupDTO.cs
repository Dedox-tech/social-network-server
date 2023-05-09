using System.ComponentModel.DataAnnotations;

namespace SocialNetworkServer.DTO
{
    public class UserSignupDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}

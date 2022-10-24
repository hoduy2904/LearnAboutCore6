using System.ComponentModel.DataAnnotations;

namespace LearnAboutNet6.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Username cannot be left blank")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password cannot be left blank")]
        public string Password { get; set; }
    }
}

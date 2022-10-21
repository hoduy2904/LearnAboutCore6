using System.ComponentModel.DataAnnotations;

namespace LearnAboutNet6.Models
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Username cannot be left blank")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Email cannot be left blank")]
        [DataType(DataType.EmailAddress,ErrorMessage = "Please enter correct email format")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Password must be the same")]
        public string PasswordRepeat { get; set; }
    }
}

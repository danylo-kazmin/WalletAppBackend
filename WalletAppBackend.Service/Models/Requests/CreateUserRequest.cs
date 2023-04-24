using System.ComponentModel.DataAnnotations;

namespace WalletAppBackend.Service.Models.Requests
{
    public class CreateUserRequest
    {
        [Required (ErrorMessage = "Username not specified!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password not specified!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "IsAdmin not specified!")]
        public bool IsAdmin { get; set; }
        [Required]
        public List<User> TrustedPersons { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace WalletAppBackend.Service.Models.Requests
{
    public class CreateUserRequest
    {
        [Required (ErrorMessage = "Name not specified!")]
        public string Username { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace WalletAppBackend.API.Models.Responses
{
    public class CreateUserResponses
    {
        [Required (ErrorMessage = "Name not specified!")]
        public string Username { get; set; }
    }
}
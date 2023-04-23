using System.ComponentModel.DataAnnotations;

namespace WalletAppBackend.Service.Models.Responses
{
    public class CreateUserResponses
    {
        [Required (ErrorMessage = "Name not specified!")]
        public string Username { get; set; }
    }
}
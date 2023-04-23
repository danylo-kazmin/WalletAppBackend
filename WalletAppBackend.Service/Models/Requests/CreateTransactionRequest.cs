using System.ComponentModel.DataAnnotations;

namespace WalletAppBackend.Service.Models.Requests
{
    public class CreateTransactionRequest
    {
        [Required]
        public string Type { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "Username not specified!")]
        public string Username { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTimeOffset Date { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string IconLink { get; set; }
        [Required]
        public Guid SenderId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
    }
}
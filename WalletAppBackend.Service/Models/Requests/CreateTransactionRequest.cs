using System.ComponentModel.DataAnnotations;

namespace WalletAppBackend.Service.Models.Requests
{
    public class CreateTransactionRequest
    {
        [RegularExpression("^(Payment|Credit)$", ErrorMessage = "Type must be either 'Payment' or 'Credit'")]
        public string Type { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTimeOffset Date { get; set; }
        [RegularExpression("(Pending|Approved)", ErrorMessage = "Status must be 'Pending' or 'Approved'")]
        public string Status { get; set; }
        [Required]
        public TrustedPerson TrustedPerson { get; set; }
        [Required]
        public User User { get; set; }
    }
}
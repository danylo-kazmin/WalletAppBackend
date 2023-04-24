using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletAppBackend.Service.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
        public string IconLink { get; set; }
        public User Sender { get; set; }
        public User User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletAppBackend.Service.Models
{
    public class CardBalance
    {
        public Guid Id { get; set; }
        public decimal MaxLimit { get; set; }
        public decimal Balance { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletAppBackend.Infrastructure.DataAccess.Contracts;

namespace WalletAppBackend.Infrastructure.DataAccess.Implementation.Entities
{
    public class TransactionEntity : IEntity
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Status { get; set; }
        public string IconLink { get; set; }
        public Guid SenderId { get; set; }
        public Guid OwnerId { get; set; }
        public UserEntity Sender { get; set; }
        public UserEntity Owner { get; set; }
    }
}

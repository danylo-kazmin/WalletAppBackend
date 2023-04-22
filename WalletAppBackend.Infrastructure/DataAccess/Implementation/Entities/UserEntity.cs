using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletAppBackend.Infrastructure.DataAccess.Contracts;

namespace WalletAppBackend.Infrastructure.DataAccess.Implementation.Entities
{
    public class UserEntity : IEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public List<TransactionEntity> Transactions { get; set; }
        public DailyPointsEntity DailyPoints { get; set; }
        public CardBalanceEntity CardBalance { get; set; }
    }
}

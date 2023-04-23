using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletAppBackend.Infrastructure.DataAccess.Contracts;

namespace WalletAppBackend.Infrastructure.DataAccess.Implementation.Entities
{
    public class DailyPointsEntity : IEntity
    {
        public Guid Id { get; set; }
        public int Points { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
    }
}

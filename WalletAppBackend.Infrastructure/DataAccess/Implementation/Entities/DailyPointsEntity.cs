using WalletAppBackend.Infrastructure.DataAccess.Contracts;

namespace WalletAppBackend.Infrastructure.DataAccess.Implementation.Entities
{
    public class DailyPointsEntity : IEntity
    {
        public Guid Id { get; set; }
        public long Points { get; set; }
        public int DayOfSeasone { get; set; }
    }
}

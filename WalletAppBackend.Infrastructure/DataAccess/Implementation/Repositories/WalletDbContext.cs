using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WalletAppBackend.Infrastructure.DataAccess.Implementation.Entities;
using WalletAppBackend.Infrastructure.DataAccess.Implementation.EntityConfigurations;

namespace WalletAppBackend.Infrastructure.DataAccess.Implementation.Repositories
{
    public class WalletDbContext : DbContext
    {
        public DbSet<TransactionEntity> Transactions { get; set; }
        public DbSet<DailyPointsEntity> DailyPoints { get; set; }
        public DbSet<CardBalanceEntity> CardBalances { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        public WalletDbContext(DbContextOptions<WalletDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new DailyPointsConfiguration());
            modelBuilder.ApplyConfiguration(new CardBalanceConfiguration());
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}

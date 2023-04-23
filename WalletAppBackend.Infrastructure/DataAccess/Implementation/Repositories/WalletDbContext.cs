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
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("AppSettings:ConnectionString");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new DailyPointsConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}

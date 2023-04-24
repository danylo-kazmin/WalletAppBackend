using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletAppBackend.Infrastructure.DataAccess.Implementation.Entities;

namespace WalletAppBackend.Infrastructure.DataAccess.Implementation.EntityConfigurations
{
    public class DailyPointsConfiguration : IEntityTypeConfiguration<DailyPointsEntity>
    {
        public void Configure(EntityTypeBuilder<DailyPointsEntity> builder)
        {
            builder.ToTable("DailyPoints").HasKey(p => p.Id);
            builder.Property(p => p.Points).IsRequired().HasColumnName("Points").HasColumnType("bigint");
            builder.Property(p => p.DayOfSeasone).IsRequired().HasColumnName("DayOfSeasone").HasColumnType("int");
        }
    }
}

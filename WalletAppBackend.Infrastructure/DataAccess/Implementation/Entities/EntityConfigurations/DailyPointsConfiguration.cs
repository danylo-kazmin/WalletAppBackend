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
            builder.Property(p => p.Points).IsRequired().HasColumnName("Points").HasColumnType("int");

            builder.HasOne(d => d.User)
                .WithOne(u => u.DailyPoints)
                .HasForeignKey<DailyPointsEntity>(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

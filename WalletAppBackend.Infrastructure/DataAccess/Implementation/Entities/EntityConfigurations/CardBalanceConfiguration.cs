using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletAppBackend.Infrastructure.DataAccess.Implementation.Entities;

namespace WalletAppBackend.Infrastructure.DataAccess.Implementation.EntityConfigurations
{
    public class CardBalanceConfiguration : IEntityTypeConfiguration<CardBalanceEntity>
    {
        public void Configure(EntityTypeBuilder<CardBalanceEntity> builder)
        {
            builder.ToTable("CardBalance");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.MaxLimit).IsRequired().HasColumnType("money");
            builder.Property(p => p.Balance).IsRequired().HasColumnType("money");
            builder.Property(p => p.UserId).IsRequired().HasColumnType("uniqueidentifier");

            builder.HasOne(с => с.User)
                .WithOne(p => p.CardBalance)
                .HasForeignKey<CardBalanceEntity>(с => с.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

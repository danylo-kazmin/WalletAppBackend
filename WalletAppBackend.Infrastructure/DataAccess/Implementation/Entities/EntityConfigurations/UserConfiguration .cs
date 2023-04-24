using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletAppBackend.Infrastructure.DataAccess.Implementation.Entities;

namespace WalletAppBackend.Infrastructure.DataAccess.Implementation.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User").HasKey(u => u.Id);
            builder.Property(u => u.Username).IsRequired().HasColumnName("Username").HasColumnType("nvarchar(50)");
            builder.Property(u => u.IconLink).IsRequired().HasColumnName("IconLink").HasColumnType("nvarchar(255)");
            builder.Property(u => u.Password).IsRequired().HasColumnName("Password").HasColumnType("nvarchar(50)");
            builder.Property(u => u.IsAdmin).IsRequired().HasColumnName("IsAdmin").HasColumnType("bit");

            builder.HasMany(u => u.Transactions)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.CardBalance)
                .WithOne(cb => cb.User)
                .HasForeignKey<CardBalanceEntity>(cb => cb.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.TrustedPersons)
                .WithOne(tp => tp.User)
                .HasForeignKey(tp => tp.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

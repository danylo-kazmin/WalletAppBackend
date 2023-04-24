using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletAppBackend.Infrastructure.DataAccess.Implementation.Entities;

namespace WalletAppBackend.Infrastructure.DataAccess.Implementation.EntityConfigurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<TransactionEntity>
    {
        public void Configure(EntityTypeBuilder<TransactionEntity> builder)
        {
            builder.ToTable("Transaction").HasKey(t => t.Id);
            builder.Property(t => t.Type).IsRequired().HasColumnName("Type").HasColumnType("nvarchar(30)");
            builder.Property(t => t.Amount).IsRequired().HasColumnName("Amount").HasColumnType("money");
            builder.Property(t => t.Name).IsRequired().HasColumnName("Name").HasColumnType("nvarchar(100)");
            builder.Property(t => t.Description).HasColumnName("Description").HasColumnType("nvarchar(500)");
            builder.Property(t => t.Date).IsRequired().HasColumnName("Date").HasColumnType("datetimeoffset(7)");
            builder.Property(t => t.Status).IsRequired().HasColumnName("Status").HasColumnType("nvarchar(30)");
            builder.Property(t => t.SenderId).IsRequired().HasColumnName("SenderId").HasColumnType("uniqueidentifier");
            builder.Property(t => t.UserId).IsRequired().HasColumnName("UserId").HasColumnType("uniqueidentifier");

            builder.HasOne(t => t.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.TrustedPerson)
                .WithMany()
                .HasForeignKey(t => t.SenderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

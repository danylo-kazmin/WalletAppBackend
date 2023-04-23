using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletAppBackend.Infrastructure.DataAccess.Implementation.Entities;

namespace WalletAppBackend.Infrastructure.DataAccess.Implementation.EntityConfigurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<TransactionEntity>
    {
        public void Configure(EntityTypeBuilder<TransactionEntity> builder)
        {
            builder.ToTable("Transaction").HasKey(p => p.Id);
            builder.Property(p => p.Type).IsRequired().HasColumnName("Type").HasColumnType("nvarchar(30)");
            builder.Property(p => p.Amount).IsRequired().HasColumnName("Amount").HasColumnType("money");
            builder.Property(p => p.Name).IsRequired().HasColumnName("Name").HasColumnType("nvarchar(100)");
            builder.Property(p => p.Description).HasColumnName("Description").HasColumnType("nvarchar(500)");
            builder.Property(p => p.Date).IsRequired().HasColumnName("Date").HasColumnType("datetimeoffset(7)");
            builder.Property(p => p.Status).IsRequired().HasColumnName("Status").HasColumnType("nvarchar(30)");
            builder.Property(p => p.IconLink).IsRequired().HasColumnName("IconLink").HasColumnType("nvarchar(100)");
            builder.Property(p => p.SenderId).IsRequired().HasColumnName("SenderId").HasColumnType("uniqueidentifier");
            builder.Property(p => p.OwnerId).IsRequired().HasColumnName("OwnerId").HasColumnType("uniqueidentifier");

            builder.HasOne(t => t.Sender)
                .WithMany()
                .HasForeignKey(t => t.SenderId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Owner)
                .WithMany()
                .HasForeignKey(t => t.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace WalletAppBackend.Infrastructure.DataAccess.Implementation.Entities.EntityConfigurations
{
    public class TrustedPersonConfiguration : IEntityTypeConfiguration<TrustedPersonEntity>
    {
        public void Configure(EntityTypeBuilder<TrustedPersonEntity> builder)
        {
            builder.ToTable("TrustedPerson").HasKey(p => p.Id);
            builder.Property(p => p.Username).IsRequired().HasColumnName("Username").HasColumnType("nvarchar(50)");

            builder.HasOne(p => p.User)
                .WithMany(u => u.TrustedPersons)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

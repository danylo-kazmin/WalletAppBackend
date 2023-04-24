using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletAppBackend.Infrastructure.DataAccess.Implementation.Entities;

namespace WalletAppBackend.Infrastructure.DataAccess.Implementation.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User").HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().HasColumnType("uniqueidentifier");
            builder.Property(x => x.IconLink).IsRequired().HasColumnName("IconLink").HasColumnType("nvarchar(255)");
            builder.Property(x => x.Username).IsRequired().HasColumnName("Username").HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired().HasColumnName("Password").HasMaxLength(50);
            builder.Property(x => x.IsAdmin).IsRequired().HasColumnName("IsAdmin").HasColumnType("bit");

            builder.HasMany(u => u.Transactions)
                .WithOne()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Navigation(u => u.Transactions)
                .UsePropertyAccessMode(PropertyAccessMode.Property)
                .IsRequired(false);
        }
    }
}

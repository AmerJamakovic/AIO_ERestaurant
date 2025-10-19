using Market.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.Infrastructure.Database.Configurations.Identity;

public sealed class PromoCodeConfiguration : IEntityTypeConfiguration<PromoCode>
{
    public void Configure(EntityTypeBuilder<PromoCode> b)
    {
        // Table name
        b.ToTable("PromoCodes");

        // Primary key
        b.HasKey(x => x.Id);

        // Properties
        b.Property(x => x.Code).IsRequired().HasMaxLength(100);

        b.HasIndex(x => x.Code).IsUnique(); // each promo code should be unique

        b.Property(x => x.DiscountType)
            .IsRequired()
            .HasConversion<string>() // store enum name instead of number
            .HasMaxLength(50);

        b.Property(x => x.Value).IsRequired().HasColumnType("decimal(10,2)");

        b.Property(x => x.ValidFrom).IsRequired(false);

        b.Property(x => x.ValidUntil).IsRequired(false);

        b.Property(x => x.IsActive).HasDefaultValue(true);

        b.Property(x => x.MaxUses).IsRequired(false);
    }
}

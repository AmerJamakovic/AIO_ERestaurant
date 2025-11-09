using Restaurant.Domain.Entities.Misc;

namespace Restaurant.Infrastructure.Database.Configurations.Misc;

public sealed class PromoCodeConfiguration : IEntityTypeConfiguration<PromoCode>
{
    public void Configure(EntityTypeBuilder<PromoCode> builder)
    {
        builder.ToTable("PromoCodes");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("PromoCodeId");

        builder.Property(x => x.Code).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Discount).IsRequired();
        builder.Property(x => x.ValidFrom).IsRequired();
        builder.Property(x => x.ValidUntil).IsRequired();
        builder.Property(x => x.IsActive).HasDefaultValue(true);
        builder.Property(x => x.MaxUses).IsRequired(false);
    }
}

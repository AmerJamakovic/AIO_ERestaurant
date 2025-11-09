using Restaurant.Domain.Common;

namespace Restaurant.Infrastructure.Database.Configurations.Identity;

public sealed class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> b)
    {
        b.ToTable("Invoices");

        b.HasKey(x => x.Id);

        b.Property(x => x.OrderId).IsRequired();

        b.HasOne(x => x.Order)
            .WithMany()
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        b.Property(x => x.TotalAmount).IsRequired();

        b.Property(x => x.PaymentMethod).IsRequired().HasConversion<string>().HasMaxLength(50);

        b.Property(x => x.PaymentStatus)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(50)
            .HasDefaultValue(PaymentStatusEnum.PENDING);

        b.Property(x => x.PromoCodeId);

        b.HasOne(x => x.PromoCode)
            .WithMany()
            .HasForeignKey(x => x.PromoCodeId)
            .OnDelete(DeleteBehavior.SetNull);

        b.Property(x => x.PaymentDate);
    }
}

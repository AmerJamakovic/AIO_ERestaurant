using Restaurant.Domain.Common;
using Restaurant.Domain.Entities.Misc;

namespace Restaurant.Infrastructure.Database.Configurations.Misc;

public sealed class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("Invoices");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("InvoiceId");

        builder.Property(x => x.OrderId).IsRequired();
        builder.HasOne(x => x.Order)
            .WithMany()
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.TotalAmount).IsRequired();
        builder.Property(x => x.PaymentMethod).IsRequired().HasConversion<string>().HasMaxLength(50);

        builder.Property(x => x.PaymentStatus)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(50)
            .HasDefaultValue(PaymentStatusEnum.PENDING);

        builder.Property(x => x.PaymentDate)
            .HasDefaultValue(DateTime.Now);
    }
}

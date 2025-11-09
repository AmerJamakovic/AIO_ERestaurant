using Restaurant.Domain.Common;
using Restaurant.Domain.Entities.PaymentProcessing;

namespace Restaurant.Infrastructure.Database.Configurations.PaymentProcessing;

public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("OrderId");

        builder.HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.Employee)
            .WithMany()
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.Table)
            .WithMany()
            .HasForeignKey(x => x.TableId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Property(x => x.OrderType)
            .IsRequired()
            .HasConversion<string>()
            .HasDefaultValue(OrderTypeEnum.DINE_IN);

        builder.Property(x => x.OrderStatus)
            .IsRequired()
            .HasConversion<string>()
            .HasDefaultValue(OrderStatusEnum.OPEN);

        builder.HasOne(x => x.PromoCode)
            .WithMany()
            .HasForeignKey(x => x.PromoCodeId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}

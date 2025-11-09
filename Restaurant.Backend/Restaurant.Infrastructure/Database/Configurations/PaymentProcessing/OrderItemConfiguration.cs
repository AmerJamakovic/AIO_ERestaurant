using Restaurant.Domain.Entities.PaymentProcessing;

namespace Restaurant.Infrastructure.Database.Configurations.PaymentProcessing;

public sealed class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("OrderItemId");

        builder.Property(x => x.OrderId).IsRequired();
        builder.Property(x => x.MenuItemId).IsRequired();

        builder.HasOne(x => x.Order)
            .WithMany()
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.MenuItem)
            .WithMany()
            .HasForeignKey(x => x.MenuItemId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Quantity).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.UnitPrice).IsRequired().HasColumnType("decimal(10,2)");
    }
}

namespace Restaurant.Infrastructure.Database.Configurations.Identity;

public sealed class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> b)
    {
        // Table name
        b.ToTable("OrderItems");

        // Primary key
        b.HasKey(x => x.Id);

        // Relationships
        b.Property(x => x.OrderId).IsRequired().HasMaxLength(450);

        b.Property(x => x.MenuItemId).IsRequired().HasMaxLength(450);

        b.HasOne(x => x.Order)
            .WithMany() // Assuming Order doesn't yet have a collection of OrderItems
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasOne(x => x.MenuItem)
            .WithMany() // Assuming MenuItem doesn't have a collection of OrderItems yet
            .HasForeignKey(x => x.MenuItemId)
            .OnDelete(DeleteBehavior.Restrict);

        // Properties
        b.Property(x => x.Quantity).IsRequired().HasDefaultValue(1);

        b.Property(x => x.UnitPriceAtOrder).IsRequired().HasColumnType("decimal(10,2)");

        b.Property(x => x.SpecialInstructions).HasMaxLength(500);
    }
}

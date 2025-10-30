using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Market.Domain.Entities.Catalog;
using Market.Domain.Common;

namespace Market.Infrastructure.Database.Configurations.Catalog;

public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> b)
    {
        // Table name
        b.ToTable("Orders");

        // Primary key
        b.HasKey(x => x.Id);

        // Relationships: Customer (User)
        b.HasOne(x => x.Customer)
            .WithMany() // assuming User doesn’t have a collection of Orders yet
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);

        // Relationships: Employee
        b.HasOne(x => x.Employee)
            .WithMany() // assuming Employee doesn’t have a collection of Orders yet
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.SetNull);

        // Relationships: Table
        b.HasOne(x => x.Table)
            .WithMany() // assuming RestaurantTable doesn’t have Orders collection yet
            .HasForeignKey(x => x.TableId)
            .OnDelete(DeleteBehavior.SetNull);

        // Enum properties
        b.Property(x => x.OrderType)
            .IsRequired()
            .HasConversion<string>() // store enum as string for readability
            .HasMaxLength(50);

        b.Property(x => x.OrderStatus)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(50)
            .HasDefaultValue(OrderStatusEnum.OPEN);

        // Other properties
        b.Property(x => x.DeliveryAddress).HasMaxLength(300);

        b.Property(x => x.Notes).HasMaxLength(500);
    }
}

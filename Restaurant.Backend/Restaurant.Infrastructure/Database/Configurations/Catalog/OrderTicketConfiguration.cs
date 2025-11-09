using Restaurant.Domain.Common;

namespace Restaurant.Infrastructure.Database.Configurations.Identity;

public sealed class OrderTicketConfiguration : IEntityTypeConfiguration<OrderTicket>
{
    public void Configure(EntityTypeBuilder<OrderTicket> builder)
    {
        builder.ToTable("OrderTickets");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("OrderTicketId").HasConversion<string>();

        builder.Property(x => x.OrderItemId).IsRequired();

        builder.HasOne(x => x.OrderItem)
            .WithMany()
            .HasForeignKey(x => x.OrderItemId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Destination).IsRequired().HasConversion<string>().HasMaxLength(50);

        builder.Property(x => x.Status)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(50)
            .HasDefaultValue(TicketStatusEnum.CREATED);

        builder.Property(x => x.Notes).HasMaxLength(500);
    }
}

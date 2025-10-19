namespace Market.Infrastructure.Database.Configurations.Identity;

public sealed class KitchenTicketConfiguration : IEntityTypeConfiguration<KitchenTicket>
{
    public void Configure(EntityTypeBuilder<KitchenTicket> b)
    {
        b.ToTable("KitchenTickets");

        b.HasKey(x => x.Id);

        b.Property(x => x.OrderItemId).IsRequired();

        b.HasOne(x => x.OrderItem)
            .WithMany()
            .HasForeignKey(x => x.OrderItemId)
            .OnDelete(DeleteBehavior.Restrict);

        b.Property(x => x.Destination).IsRequired().HasConversion<string>().HasMaxLength(50);

        b.Property(x => x.Status)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(50)
            .HasDefaultValue(TicketStatusEnum.SENT);

        b.Property(x => x.Notes).HasMaxLength(500);
    }
}

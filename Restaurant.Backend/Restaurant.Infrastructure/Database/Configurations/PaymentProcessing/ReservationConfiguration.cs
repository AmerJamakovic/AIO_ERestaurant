using Restaurant.Domain.Common;
using Restaurant.Domain.Entities.PaymentProcessing;

namespace Restaurant.Infrastructure.Database.Configurations.PaymentProcessing;

public sealed class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.ToTable("Reservations");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ReservationId");

        builder.Property(x => x.CustomerId).IsRequired();
        builder.HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.TableId).IsRequired(false);
        builder.HasOne(x => x.Table)
            .WithMany()
            .HasForeignKey(x => x.TableId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Property(x => x.ReservationDate).IsRequired();
        builder.Property(x => x.PartySize).IsRequired();

        builder.Property(x => x.Status).HasDefaultValue(ReservationStatusEnum.PENDING);
        builder.Property(x => x.Status)
            .IsRequired()
            .HasConversion<string>();

        builder.HasIndex(x => new { x.CustomerId, x.ReservationDate });
    }
}

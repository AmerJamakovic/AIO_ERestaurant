using Restaurant.Domain.Common;

namespace Restaurant.Infrastructure.Database.Configurations.Identity;

public sealed class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> b)
    {
        // Table name
        b.ToTable("Reservations");

        // Primary key
        b.HasKey(x => x.Id);

        // Relationships
        b.HasOne(x => x.Customer)
            .WithMany() // optional: could be WithMany(x => x.Reservations) if added later in User
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasOne(x => x.Table)
            .WithMany() // optional: could be WithMany(x => x.Reservations)
            .HasForeignKey(x => x.TableId)
            .OnDelete(DeleteBehavior.SetNull);

        // Properties
        b.Property(x => x.CustomerId).IsRequired();

        b.Property(x => x.TableId).IsRequired(false);

        b.Property(x => x.ReservationDate).IsRequired();

        b.Property(x => x.PartySize).IsRequired();

        b.Property(x => x.SpecialRequests).HasMaxLength(500);

        b.Property(x => x.Status)
            .IsRequired()
            .HasConversion<string>() // Store enum as readable text
            .HasMaxLength(50);

        // Indexes
        b.HasIndex(x => new { x.CustomerId, x.ReservationDate });

        // Default values
        b.Property(x => x.Status).HasDefaultValue(ReservationStatusEnum.PENDING);
    }
}

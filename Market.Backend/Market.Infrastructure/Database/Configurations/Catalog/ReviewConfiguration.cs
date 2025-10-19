namespace Market.Infrastructure.Database.Configurations.Identity;

public sealed class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> b)
    {
        // Table name
        b.ToTable("Reviews");

        // Primary key
        b.HasKey(x => x.Id);

        // Relationships
        b.HasOne(x => x.Customer)
            .WithMany() // Optional: could be WithMany(x => x.Reviews) if added in User
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Cascade); // deleting a user deletes their reviews

        b.HasOne(x => x.MenuItem)
            .WithMany() // Optional: could be WithMany(x => x.Reviews)
            .HasForeignKey(x => x.MenuItemId)
            .OnDelete(DeleteBehavior.SetNull); // keep review if menu item deleted

        // Properties
        b.Property(x => x.CustomerId).IsRequired().HasMaxLength(450);

        b.Property(x => x.MenuItemId).IsRequired(false).HasMaxLength(450);

        b.Property(x => x.Rating).IsRequired();

        b.Property(x => x.Comment).HasMaxLength(1000);

        b.Property(x => x.IsApproved).HasDefaultValue(false);

        // Optional index for quick lookup per menu item
        b.HasIndex(x => x.MenuItemId);
    }
}

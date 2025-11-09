using Restaurant.Domain.Entities.Misc;

namespace Restaurant.Infrastructure.Database.Configurations.Misc;

public sealed class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("Reviews");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ReviewId");

        builder.HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Cascade); // Delete reviews if the customer is deleted

        builder.HasOne(x => x.MenuItem)
            .WithMany()
            .HasForeignKey(x => x.MenuItemId)
            .OnDelete(DeleteBehavior.SetNull); // Keep the review even if the menu item is deleted

        builder.Property(x => x.CustomerId).IsRequired();
        builder.Property(x => x.Rating).IsRequired();
        builder.Property(x => x.Comment).HasMaxLength(200);

        builder.HasIndex(x => x.MenuItemId); // Index on MenuItemId for faster queries
    }
}

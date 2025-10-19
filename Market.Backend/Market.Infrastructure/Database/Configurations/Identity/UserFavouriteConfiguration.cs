namespace Market.Infrastructure.Database.Configurations.Identity;

public sealed class UserFavoriteConfiguration : IEntityTypeConfiguration<UserFavorite>
{
    public void Configure(EntityTypeBuilder<UserFavorite> b)
    {
        b.ToTable("UserFavorites");

        // Composite key
        b.HasKey(x => new { x.CustomerId, x.MenuItemId });

        // Relationships
        b.HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasOne(x => x.MenuItem)
            .WithMany()
            .HasForeignKey(x => x.MenuItemId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

namespace Restaurant.Infrastructure.Database.Configurations.Identity;

public sealed class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> b)
    {
        // Table name
        b.ToTable("MenuItems");

        // Primary key
        b.HasKey(x => x.Id);

        // Index for fast search by name (optional)
        b.HasIndex(x => x.Name);

        // Property configurations
        b.Property(x => x.Name).IsRequired().HasMaxLength(150);

        b.Property(x => x.Description).HasMaxLength(500);

        b.Property(x => x.Price).IsRequired().HasColumnType("decimal(10,2)"); // standard price format

        b.Property(x => x.Calories).HasDefaultValue(null);

        b.Property(x => x.IsSpecial).HasDefaultValue(false);

        b.Property(x => x.ImageUrl).HasMaxLength(500);

        b.Property(x => x.IsAvailable).HasDefaultValue(true);

        b.Property(x => x.IsActive).HasDefaultValue(true);

        // Foreign key relationship: MenuItem → MenuGroup (optional)
        b.HasOne(x => x.Group)
            .WithMany() // or .WithMany(g => g.MenuItems) if you later add collection
            .HasForeignKey(x => x.GroupId)
            .OnDelete(DeleteBehavior.SetNull); // when group deleted, keep menu item but null GroupId
    }
}

namespace Restaurant.Infrastructure.Database.Configurations.Identity;

public sealed class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        builder.ToTable("MenuItems");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("MenuItemId");

        builder.HasIndex(x => x.Name);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);

        builder.Property(x => x.Description).HasMaxLength(300);
        
        // NOTE: 10.2 decimal is a standard format
        builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(10,2)");

        builder.Property(x => x.Calories).HasDefaultValue(null);
        builder.Property(x => x.IsAvailable).HasDefaultValue(true);
        builder.Property(x => x.IsActive).HasDefaultValue(true);

        builder.HasOne(x => x.MenuGroup)
            .WithMany()
            .HasForeignKey(x => x.MenuGroupId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}

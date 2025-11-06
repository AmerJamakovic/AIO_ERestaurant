namespace Restaurant.Infrastructure.Database.Configurations.Identity;

public sealed class MenuGroupConfiguration : IEntityTypeConfiguration<MenuGroup>
{
    public void Configure(EntityTypeBuilder<MenuGroup> b)
    {
        // Table name
        b.ToTable("MenuGroups");

        // Primary key
        b.HasKey(x => x.Id);

        // Properties
        b.Property(x => x.Name).IsRequired().HasMaxLength(150); // reasonable limit for names

        b.Property(x => x.Description).HasMaxLength(500); // optional text field

        // You could also add indexes if needed, for example:
        // b.HasIndex(x => x.Name).IsUnique(); // optional
    }
}

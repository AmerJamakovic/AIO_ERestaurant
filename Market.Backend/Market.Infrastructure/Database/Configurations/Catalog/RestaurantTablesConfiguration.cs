namespace Market.Infrastructure.Database.Configurations.Identity;

public sealed class RestaurantTableConfiguration : IEntityTypeConfiguration<RestaurantTable>
{
    public void Configure(EntityTypeBuilder<RestaurantTable> b)
    {
        // Table name
        b.ToTable("RestaurantTables");

        // Primary key
        b.HasKey(x => x.Id);

        // Properties
        b.Property(x => x.Number).IsRequired();

        b.HasIndex(x => x.Number).IsUnique(); // Each table number must be unique

        b.Property(x => x.NumberOfSets).IsRequired();

        b.Property(x => x.IsAvailable).HasDefaultValue(true);

        // You can add future relationships here
        // Example: b.HasMany(x => x.Reservations).WithOne(x => x.Table)
    }
}

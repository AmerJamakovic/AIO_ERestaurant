namespace Restaurant.Infrastructure.Database.Configurations.Identity;

public sealed class RestaurantTableConfiguration : IEntityTypeConfiguration<RestaurantTable>
{
    public void Configure(EntityTypeBuilder<RestaurantTable> builder)
    {
        builder.ToTable("RestaurantTables");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("RestaurantTableId").HasConversion<string>();

        builder.Property(x => x.Number).IsRequired();
        builder.HasIndex(x => x.Number).IsUnique();
        
        builder.Property(x => x.NumberOfSeats).IsRequired();
        builder.Property(x => x.IsAvailable).HasDefaultValue(true);
    }
}

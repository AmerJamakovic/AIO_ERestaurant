namespace Restaurant.Infrastructure.Database.Configurations.Identity;

public sealed class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.ToTable("Inventories");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("InventoryId");

        builder.Property(x => x.IngredientId).IsRequired();

        builder.HasOne(x => x.Ingredient)
            .WithMany()
            .HasForeignKey(x => x.IngredientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.QuantityInStock).IsRequired();
        builder.Property(x => x.Unit).IsRequired().HasMaxLength(50);
        builder.Property(x => x.ReorderLevel).IsRequired();
        builder.Property(x => x.ReorderQuantity).IsRequired();
        builder.Property(x => x.SupplierName).HasMaxLength(200);
        builder.Property(x => x.LastRestocked);
    }
}

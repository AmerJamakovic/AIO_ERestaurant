namespace Market.Infrastructure.Database.Configurations.Identity;

public sealed class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> b)
    {
        b.ToTable("Inventories");

        b.HasKey(x => x.Id);

        b.Property(x => x.IngredientId).IsRequired();

        b.HasOne(x => x.Ingredient)
            .WithMany()
            .HasForeignKey(x => x.IngredientId)
            .OnDelete(DeleteBehavior.Restrict);

        b.Property(x => x.QuantityInStock).IsRequired();
        b.Property(x => x.Unit).IsRequired().HasMaxLength(50);
        b.Property(x => x.ReorderLevel).IsRequired();
        b.Property(x => x.ReorderQuantity).IsRequired();
        b.Property(x => x.SupplierName).HasMaxLength(200);
        b.Property(x => x.LastRestocked);
    }
}

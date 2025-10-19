namespace Market.Infrastructure.Database.Configurations.Identity;

public sealed class MenuItemIngredientConfiguration : IEntityTypeConfiguration<MenuItemIngredient>
{
    public void Configure(EntityTypeBuilder<MenuItemIngredient> b)
    {
        // Table name
        b.ToTable("MenuItemIngredients");

        // Primary key
        b.HasKey(x => x.Id);

        // Foreign keys
        b.Property(x => x.MenuItemId).IsRequired().HasMaxLength(450); // assuming string IDs (GUIDs as strings)

        b.Property(x => x.IngredientId).IsRequired().HasMaxLength(450);

        // Relationships
        b.HasOne(x => x.MenuItem)
            .WithMany() // assuming MenuItem doesn’t have a collection yet
            .HasForeignKey(x => x.MenuItemId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasOne(x => x.Ingredient)
            .WithMany() // assuming Ingredient doesn’t have a collection yet
            .HasForeignKey(x => x.IngredientId)
            .OnDelete(DeleteBehavior.Cascade);

        // Optional: prevent duplicates
        b.HasIndex(x => new { x.MenuItemId, x.IngredientId }).IsUnique();
    }
}

namespace Restaurant.Infrastructure.Database.Configurations.Identity;

public sealed class MenuItemIngredientConfiguration : IEntityTypeConfiguration<MenuItemIngredient>
{
    public void Configure(EntityTypeBuilder<MenuItemIngredient> builder)
    {
        builder.ToTable("MenuItemIngredients");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("MenuItemIngredientId");

        builder.Property(x => x.MenuItemId).IsRequired();
        builder.Property(x => x.IngredientId).IsRequired();

        builder.HasOne(x => x.MenuItem)
            .WithMany()
            .HasForeignKey(x => x.MenuItemId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Ingredient)
            .WithMany()
            .HasForeignKey(x => x.IngredientId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new { x.MenuItemId, x.IngredientId }).IsUnique();
    }
}

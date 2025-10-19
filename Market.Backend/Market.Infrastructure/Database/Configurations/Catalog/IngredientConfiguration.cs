namespace Market.Infrastructure.Database.Configurations.Identity;

public sealed class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> b)
    {
        b.ToTable("Ingredients");

        b.HasKey(x => x.Id);

        b.Property(x => x.Id).HasColumnName("IngredientID");

        b.Property(x => x.Name).IsRequired().HasMaxLength(150);

        b.Property(x => x.AllergenType).HasDefaultValue(AllergenTypeEnum.NONE);
    }
}

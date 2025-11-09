using Restaurant.Domain.Common;
using Restaurant.Domain.Entities.Misc;

namespace Restaurant.Infrastructure.Database.Configurations.Misc;

public sealed class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.ToTable("Ingredients");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("IngredientId");

        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
        builder.Property(x => x.AllergenType).HasDefaultValue(AllergenTypeEnum.NONE);
    }
}

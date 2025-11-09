using Restaurant.Domain.Entities.Misc;

namespace Restaurant.Infrastructure.Database.Configurations.Misc;

public sealed class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.ToTable("Games");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("GameId");

        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.PlaceWon).IsRequired();
        builder.Property(x => x.DateHeld).IsRequired();
        builder.Property(x => x.Category).IsRequired();
        builder.Property(x => x.Description).IsRequired(false);
    }
}

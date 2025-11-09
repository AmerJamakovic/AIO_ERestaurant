namespace Restaurant.Infrastructure.Database.Configurations.Identity;

public sealed class MenuGroupConfiguration : IEntityTypeConfiguration<MenuGroup>
{
    public void Configure(EntityTypeBuilder<MenuGroup> builder)
    {
        builder.ToTable("MenuGroups");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("MenuGroupId");

        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
        builder.Property(x => x.Description).HasMaxLength(500);
    }
}

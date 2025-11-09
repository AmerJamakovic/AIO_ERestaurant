using Restaurant.Domain.Common;

namespace Restaurant.Infrastructure.Database.Configurations.Identity;

public sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("CustomerId");

        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(200);
        builder.Property(x => x.PasswordHash).IsRequired();
        builder.Property(x => x.PhoneNumber).HasMaxLength(50);
        builder.Property(x => x.Address).HasMaxLength(200);
        builder.Property(x => x.IsVerified).HasDefaultValue(false);
        builder.Property(x => x.IsActive).HasDefaultValue(true);
        builder.Property(x => x.Role)
            .HasConversion<string>() // store enum as string 
            .HasMaxLength(50)
            .HasDefaultValue(RoleEnum.CUSTOMER);
    }
}

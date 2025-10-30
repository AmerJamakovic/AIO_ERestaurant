using Market.Domain.Common;
using Market.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.Infrastructure.Database.Configurations.Identity;

public sealed class UserConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> b)
    {
        // Table name
        b.ToTable("Users");

        // Primary key
        b.HasKey(x => x.Id);

        // Unique index on Email
        b.HasIndex(x => x.Email).IsUnique();

        // Properties
        b.Property(x => x.FirstName).IsRequired().HasMaxLength(100);

        b.Property(x => x.LastName).IsRequired().HasMaxLength(100);

        b.Property(x => x.Email).IsRequired().HasMaxLength(200);

        b.Property(x => x.PasswordHash).IsRequired();

        b.Property(x => x.PhoneNumber).HasMaxLength(50);

        b.Property(x => x.Address).HasMaxLength(250);

        b.Property(x => x.IsVerified).HasDefaultValue(false);

        b.Property(x => x.IsActive).HasDefaultValue(true);

        b.Property(x => x.Role)
            .HasConversion<string>() // store enum as string (optional)
            .HasMaxLength(50)
            .HasDefaultValue(RoleEnum.CUSTOMER);
    }
}

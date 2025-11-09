namespace Restaurant.Infrastructure.Database.Configurations.Identity;

public sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("EmployeeId");

        builder.Property(x => x.JobTitle).IsRequired().HasConversion<string>().HasMaxLength(50);

        builder.Property(x => x.BirthDate);
        builder.Property(x => x.HireDate);
        builder.Property(x => x.YearsOfExperience).HasDefaultValue(0);
    }
}

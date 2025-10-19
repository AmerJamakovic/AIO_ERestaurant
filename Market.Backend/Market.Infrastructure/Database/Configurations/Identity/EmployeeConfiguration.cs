namespace Market.Infrastructure.Database.Configurations.Identity;

public sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> b)
    {
        b.ToTable("Employees");

        b.HasKey(x => x.Id);

        b.Property(x => x.JobTitle).IsRequired().HasConversion<string>().HasMaxLength(50);

        b.Property(x => x.BirthDate);
        b.Property(x => x.HireDate);
        b.Property(x => x.YearsOfExperience).HasDefaultValue(0);
    }
}

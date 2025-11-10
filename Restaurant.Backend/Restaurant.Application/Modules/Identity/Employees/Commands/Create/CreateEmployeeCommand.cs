using Restaurant.Domain.Common;

namespace Restaurant.Application.Modules.Identity.Employees.Commands.Create;

public class CreateEmployeeCommand : IRequest<Employee>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required JobTitleEnum JobTitle { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? HireDate { get; set; }
    public int YearsOfExperience { get; set; } = 0;
}

namespace Market.Application.Modules.Identity.Employees.Commands.Create
{
    public class CreateEmployeeCommand : IRequest<Employee>
    {
        public required JobTitleEnum JobTitle { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public int YearsOfExperience { get; set; } = 0;
    }
}

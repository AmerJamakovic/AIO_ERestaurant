namespace Restaurant.Application.Modules.Identity.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQueryDto
    {
        public string FirstName { get; } = null!;
        public string LastName { get; } = null!;
        public DateTime BirthDate { get; }
        public DateTime HireDate { get; }
        public int YearsOfExperience { get; }
    }
}

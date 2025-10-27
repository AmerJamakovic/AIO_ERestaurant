namespace Market.Application.Modules.Identity.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQueryDto
    {
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime BirthDate { get; }
        public DateTime HireDate { get; }
        public int YearsOfExperience { get; }
    }
}

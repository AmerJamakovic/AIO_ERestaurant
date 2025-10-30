namespace Market.Application.Modules.Identity.Employees.Commands.Create
{
    public class CreateEmployeeHandlerCommand(IAppDbContext context)
        : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken ct)
        {
            if (request.YearsOfExperience < 0) // Checks value in case that user maybe provide negative value
                throw new Exception("Invalid input.");
            else if ((int)request.JobTitle > 5)
            {
                throw new Exception("Invalid input.");
            }
            else if (request.HireDate is not null) // Checks if user provide year that is in the future
            {
                if (request.HireDate.Value.Year > DateTime.Now.Year)
                {
                    throw new Exception("Invalid.");
                }
            }
            else if (request.BirthDate is not null) // Checks if user provide year that is in the future
            {
                if (
                    request.BirthDate.Value.Year < 1900
                    || request.YearsOfExperience
                        > (DateTime.Now.Year - request.BirthDate.Value.Year)
                )
                {
                    throw new Exception("Invalid input.");
                }
            }

            var employee = CreateEmployee(request);

            context.Employees.Add(employee);

            await context.SaveChangesAsync(ct);

            return employee;
        }

        public Employee CreateEmployee(CreateEmployeeCommand request)
        {
            var hasher = new PasswordHasher<UserBaseEntity>();

            var employee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                JobTitle = request.JobTitle,
                BirthDate = request.BirthDate,
                HireDate = request.HireDate,
                YearsOfExperience = request.YearsOfExperience,
                PasswordHash = hasher.HashPassword(null!, request.Password),
            };

            return employee;
        }
    }
}

namespace Market.Application.Modules.Identity.Employees.Commands.Update
{
    public class UpdateEmployeeHandlerCommand(IAppDbContext context) : IRequestHandler<UpdateEmployeeCommand, Employee>
    {
        public async Task<Employee> Handle(UpdateEmployeeCommand request, CancellationToken ct)
        {
            // beta version.. need more validation logic

            // maybe check if the user is admin so it has privileges to update or delete record of employee in db

            if (string.IsNullOrWhiteSpace(request.Id)) // Checks that id is empty or null and in that case throw exception
                throw new Exception("Id isn't valid!");

            else if ((int)request.JobTitle > 5) // Checks if the user provide invalid role option
            {
                throw new Exception("Invalid role option!");
            }

            else if (request.YearsOfExperience < 0) // Checks value in case that the user maybe provide negative value
                throw new Exception("Invalid input for years of experience, needs to be positive.");

            else if (request.HireDate is not null)
            {
                if (request.HireDate.Value.Year > DateTime.Now.Year) // Checks if the user provide a year that is in the future
                {
                    throw new Exception("Invalid input for years of experience, needs to be positive.");
                }
            }
            else if (request.BirthDate is not null) 
            {
                if (request.BirthDate.Value.Year < 1900) // Checks if the user provide a birth year older than 1900.
                {
                    throw new Exception("Invalid input for years of experience, needs to be positive.");
                }
            }

            var employee = await context.Employees.FirstOrDefaultAsync(e => e.Id == request.Id, ct);
            // Checks whether the employee exists in database or not

            if (employee is null)
                throw new MarketNotFoundException("Employee is not found..");


            employee.JobTitle = request.JobTitle;
            employee.BirthDate = request.BirthDate;
            employee.HireDate = request.HireDate;
            employee.YearsOfExperience = request.YearsOfExperience;

            await context.SaveChangesAsync(ct);

            return employee;
        }
    }
}

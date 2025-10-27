using Market.Domain.Entities.Identity;
namespace Market.Application.Modules.Identity.Employees.Commands.Create
{
    public class CreateEmployeeHandlerCommand(IAppDbContext context) : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken ct)
        {
            // Dodati logiku za provjeru i validnost prije samog dodavanja.. 
            // Beta verzija

                //request.BirthDate.Value.Year == 2025  too young

            // should add Jobtitle validation..

            if (request.YearsOfExperience < 0) // Checks value in case that user maybe provide negative value
                throw new Exception("Invalid input for years of experience, needs to be positive.");

            else if (request.HireDate is not null) // Checks if user provide year that is in the future
            {
                if (request.HireDate.Value.Year > DateTime.Now.Year)
                {
                    throw new Exception("Invalid.");
                }
            }
            else if (request.BirthDate is not null) // Checks if user provide year that is in the future
            {
                if (request.BirthDate.Value.Year < 1900)
                {
                    throw new Exception("Invalid.");
                }
            }


            // dodati vrijednosti bazne..

            var employee = new Employee
            {
                JobTitle = request.JobTitle,
                BirthDate = request.BirthDate,
                HireDate = request.HireDate,
                YearsOfExperience = request.YearsOfExperience
            };

            context.Employees.Add(employee);

            await context.SaveChangesAsync(ct);

            return employee; // Dogovoriti sta ce vracati metoda kreiranja zaposlenika
            // VRATIT OBJEKAT!
        }
    }
}

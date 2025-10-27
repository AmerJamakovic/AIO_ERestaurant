using Market.Domain.Entities.Identity;
namespace Market.Application.Modules.Identity.Employees.Commands.Create
{
    public class CreateEmployeeHandlerCommand(IAppDbContext context) : IRequestHandler<CreateEmployeeCommand, string>
    {
        public async Task<string> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            // Dodati logiku za provjeru i validnost prije samog dodavanja.. 
            // Beta verzija

            var employee = new Employee
            {
                JobTitle = request.JobTitle,
                BirthDate = request.BirthDate,
                HireDate = request.HireDate,
                YearsOfExperience = request.YearsOfExperience
            };

            context.Employees.Add(employee);

            await context.SaveChangesAsync(cancellationToken);

            return employee.Id; // Dogovoriti sta ce vracati metoda kreiranja zaposlenika
        }
    }
}

using Market.Application.Modules.Identity.Employees.Commands.Delete;
namespace Market.Application.Modules.Identity.Employees.Commands.Create
{
    public class DeleteEmployeeHandlerCommand(IAppDbContext context) : IRequestHandler<DeleteEmployeeCommand, string>
    {
        public async Task<string> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            // Dodati logiku za provjeru i validnost prije samog brisanja.. 
            // Beta verzija

            var employeeForDelete = await context.Employees.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            context.Employees.Remove(employeeForDelete);

            return employeeForDelete.Id; // Dogovoriti sta ce vracati metoda kreiranja zaposlenika
        }
    }
}

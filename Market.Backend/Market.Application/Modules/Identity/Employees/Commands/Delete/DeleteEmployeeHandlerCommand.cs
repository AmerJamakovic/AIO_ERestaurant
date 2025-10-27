namespace Market.Application.Modules.Identity.Employees.Commands.Delete
{
    public class DeleteEmployeeHandlerCommand(IAppDbContext context) : IRequestHandler<DeleteEmployeeCommand, Employee>
    {
        public async Task<Employee> Handle(DeleteEmployeeCommand request, CancellationToken ct)
        {
            // Dodati logiku za provjeru i validnost prije samog brisanja.. 
            // Beta verzija

            var employeeForDelete = await context.Employees.FirstOrDefaultAsync(e => e.Id == request.Id, ct);
            // Checks whether the employee exists in database or not

            if (employeeForDelete is null)
                throw new MarketNotFoundException("User is not found in database, check the userId and try again!");

            context.Employees.Remove(employeeForDelete);
            await context.SaveChangesAsync(ct);

            return employeeForDelete; // Dogovoriti sta ce vracati metoda kreiranja zaposlenika
        }
    }
}

namespace Market.Application.Modules.Identity.Employees.Commands.Delete
{
    public class DeleteEmployeeHandlerCommand(IAppDbContext context)
        : IRequestHandler<DeleteEmployeeCommand, Employee>
    {
        public async Task<Employee> Handle(DeleteEmployeeCommand request, CancellationToken ct)
        {
            // Should add some logic to check if the current user have permission/role to delete other user

            var employeeForDelete = await context.Employees.FirstOrDefaultAsync(
                e => e.Id == request.Id,
                ct
            );
            // Checks whether the employee exists in database or not

            if (employeeForDelete is null)
                throw new MarketNotFoundException("User is not found.");

            context.Employees.Remove(employeeForDelete);
            await context.SaveChangesAsync(ct);

            return employeeForDelete;
        }
    }
}

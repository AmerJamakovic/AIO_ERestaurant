namespace Market.Application.Modules.Identity.Employees.Commands.Delete
{
    public class DeleteEmployeeCommand : IRequest<Employee>
    {
        public string Id { get; set; }
    }
}

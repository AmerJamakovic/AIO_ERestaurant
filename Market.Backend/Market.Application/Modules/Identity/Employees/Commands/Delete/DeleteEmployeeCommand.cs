namespace Market.Application.Modules.Identity.Employees.Commands.Delete
{
    public class DeleteEmployeeCommand : IRequest<string>
    {
        public string Id { get; set; }
    }
}

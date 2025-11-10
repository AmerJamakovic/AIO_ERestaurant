using System.Text.Json.Serialization;

namespace Restaurant.Application.Modules.Identity.Employees.Commands.Delete;

public class DeleteEmployeeCommand : IRequest<Employee>
{
    [JsonIgnore]
    public string Id { get; set; } = string.Empty;
}

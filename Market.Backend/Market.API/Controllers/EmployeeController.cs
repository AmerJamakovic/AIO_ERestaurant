using Market.Application.Modules.Identity.Employees.Commands.Create;
using Market.Domain.Entities.Identity;

namespace Market.API.Controllers
{
    [ApiController]
    [Route("controller")]
    public class EmployeeController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(CreateEmployeeCommand command, CancellationToken ct)
        {
           var result = await sender.Send(command, ct);

           return result;
        }
    }
}

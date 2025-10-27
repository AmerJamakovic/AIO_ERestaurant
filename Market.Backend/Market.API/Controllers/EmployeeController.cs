using Market.Application.Modules.Identity.Employees.Commands.Create;
using Market.Application.Modules.Identity.Employees.Commands.Update;
using Market.Domain.Entities.Identity;

namespace Market.API.Controllers
{
    [ApiController]
    [Route("controller/[action]")]
    public class EmployeeController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(CreateEmployeeCommand command, CancellationToken ct)
        {
           var result = await sender.Send(command, ct);

           return result;
        }

       [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(string id, UpdateEmployeeCommand command, CancellationToken ct)
        {
            command.Id = id;
            var result = await sender.Send(command, ct);

            return result;
        }
    }
}

using Market.Application.Modules.Identity.Employees.Commands.Create;
using Market.Application.Modules.Identity.Employees.Commands.Delete;
using Market.Application.Modules.Identity.Employees.Commands.Update;
using Market.Application.Modules.Identity.Employees.Queries.GetEmployeeById;
using Market.Domain.Entities.Identity;

namespace Market.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(
            CreateEmployeeCommand command,
            CancellationToken ct
        )
        {
            var result = await sender.Send(command, ct);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(
            Guid id,
            UpdateEmployeeCommand command,
            CancellationToken ct
        )
        {
            var idStr = id.ToString();
            command.Id = idStr;
            var result = await sender.Send(command, ct);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id, CancellationToken ct)
        {
            var command = new DeleteEmployeeCommand { Id = id.ToString() };
            await sender.Send(command, ct);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetEmployeeByIdQueryDto>> GetEmployeeById(
            Guid id,
            CancellationToken ct
        )
        {
            var query = new GetEmployeeByIdQuery { Id = id.ToString() };
            var result = await sender.Send(query, ct);
            if (result == null)
                return NotFound();
            return result;
        }
    }
}

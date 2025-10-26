using Market.Application.Modules.Identity.Employees.Commands;

namespace Market.API.Controllers
{
    [ApiController]
    [Route("controller")]
    public class EmployeeController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<string>> CreateEmployee(CreateEmployeeCommand command, CancellationToken ct)
        {
           string result = await sender.Send(command, ct);

           return result;
        }
    }
}

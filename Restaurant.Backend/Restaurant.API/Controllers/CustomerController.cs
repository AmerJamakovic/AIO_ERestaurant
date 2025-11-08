using Market.Application.Modules.Identity.Customer.Commands.Create;
using Market.Application.Modules.Identity.Customer.Commands.Delete;
using Market.Application.Modules.Identity.Customer.Commands.Update;
using Market.Application.Modules.Identity.Customer.Queries;
using Market.Shared.Dtos.Identity;

namespace Market.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<CreateCustomerDto>> Create([FromBody] CreateCustomerCommand command) =>
            Ok(await Mediator.Send(command));

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateCustomerDto>> Update(
            Guid id,
            [FromBody] UpdateCustomerCommand command
        ) 
        {
            command.Id = id.ToString();
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteCustomerDto>> Delete(Guid id)
        {
            var customer = new DeleteCustomerCommand { Id = id.ToString() };
            return Ok(await Mediator.Send(customer));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetById(string id) =>
            Ok(await Mediator.Send(new GetCustomerByIdQuery(id)));

        [HttpGet]
        public async Task<ActionResult<PageResult<CustomerDto>>> GetAll(
            [FromQuery] PageRequest pageRequest
        ) => Ok(await Mediator.Send(new GetCustomersQuery(pageRequest)));
    }
}

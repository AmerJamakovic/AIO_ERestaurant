using Restaurant.Application.Modules.Identity.Customer.Commands.Create;
using Restaurant.Application.Modules.Identity.Customer.Commands.Delete;
using Restaurant.Application.Modules.Identity.Customer.Commands.Update;
using Restaurant.Application.Modules.Identity.Customer.Queries;
using Restaurant.Shared.Dtos.Identity;

namespace Restaurant.API.Controllers
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
            string id,
            [FromBody] UpdateCustomerCommand command
        ) 
        {
            command.Id = id.ToString();
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteCustomerDto>> Delete(string id)
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

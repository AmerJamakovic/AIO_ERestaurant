using System.Threading.Tasks;
using Market.Application.Common;
using Market.Application.Modules.Identity.Customer.Commands;
using Market.Application.Modules.Identity.Customer.Queries;
using Market.Shared.Dtos.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Market.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> Create([FromBody] CreateCustomerDto dto) =>
            Ok(await Mediator.Send(new CreateCustomerCommand(dto)));

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerDto>> Update(
            string id,
            [FromBody] UpdateCustomerDto dto
        ) => Ok(await Mediator.Send(new UpdateCustomerCommand(id, dto)));

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(string id) =>
            Ok(await Mediator.Send(new DeleteCustomerCommand(id)));

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetById(string id) =>
            Ok(await Mediator.Send(new GetCustomerByIdQuery(id)));

        [HttpGet]
        public async Task<ActionResult<PageResult<CustomerDto>>> GetAll(
            [FromQuery] PageRequest pageRequest
        ) => Ok(await Mediator.Send(new GetCustomersQuery(pageRequest)));
    }
}

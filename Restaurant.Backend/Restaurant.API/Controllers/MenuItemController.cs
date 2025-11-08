using Market.Application.Modules.Catalog.Products.Commands.Create;
using Market.Application.Modules.Catalog.Products.Commands.Delete;
using Market.Application.Modules.Catalog.Products.Commands.Update;
using Market.Domain.Entities.Catalog;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<MenuItem>> CreateMenuItem(
            CreateMenuItemCommand command,
            CancellationToken ct
        )
        {
            var result = await sender.Send(command, ct);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MenuItem>> UpdateMenuItem(
            string id,
            UpdateMenuItemCommand command,
            CancellationToken ct
        )
        {
            if (id != command.Id)
                return BadRequest("Id mismatch");
            var result = await sender.Send(command, ct);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(string id, CancellationToken ct)
        {
            var command = new DeleteMenuItemCommand { Id = id };
            var result = await sender.Send(command, ct);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}

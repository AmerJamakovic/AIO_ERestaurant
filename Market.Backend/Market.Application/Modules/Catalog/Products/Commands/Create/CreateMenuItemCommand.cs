using Market.Domain.Entities.Catalog;
using MediatR;

namespace Market.Application.Modules.Catalog.Products.Commands.Create
{
    public class CreateMenuItemCommand : IRequest<MenuItem>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public required string GroupId { get; set; }
    }
}

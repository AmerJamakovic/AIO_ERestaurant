using Market.Domain.Entities.Catalog;
using MediatR;

namespace Market.Application.Modules.Catalog.Products.Commands.Update
{
    public class UpdateMenuItemCommand : IRequest<MenuItem>
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public required string GroupId { get; set; }
    }
}

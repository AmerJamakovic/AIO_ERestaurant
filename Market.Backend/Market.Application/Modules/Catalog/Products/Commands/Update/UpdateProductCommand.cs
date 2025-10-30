using MediatR;
using Market.Domain.Entities.Catalog;

namespace Market.Application.Modules.Catalog.Products.Commands.Update
{
    public class UpdateProductCommand : IRequest<MenuItem>
    {
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required string GroupId { get; set; }
    }
}

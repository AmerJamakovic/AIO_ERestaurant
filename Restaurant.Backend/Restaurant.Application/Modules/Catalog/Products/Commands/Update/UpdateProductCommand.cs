using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Application.Modules.Catalog.Products.Commands.Update
{
    public class UpdateProductCommand : IRequest<MenuItem>
    {
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required string MenuGroupId { get; set; }
    }
}

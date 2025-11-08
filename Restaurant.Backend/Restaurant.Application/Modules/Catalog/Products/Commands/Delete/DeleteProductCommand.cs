namespace Restaurant.Application.Modules.Catalog.Products.Commands.Delete
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public required string Id { get; set; }
    }
}

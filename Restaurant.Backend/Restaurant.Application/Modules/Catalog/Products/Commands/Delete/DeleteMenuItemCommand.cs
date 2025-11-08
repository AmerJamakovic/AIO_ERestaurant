namespace Restaurant.Application.Modules.Catalog.Products.Commands.Delete
{
    public class DeleteMenuItemCommand : IRequest<bool>
    {
        public required string Id { get; set; }
    }
}

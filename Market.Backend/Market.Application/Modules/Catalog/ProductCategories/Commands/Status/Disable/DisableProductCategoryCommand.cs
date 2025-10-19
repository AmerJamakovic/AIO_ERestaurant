namespace Market.Application.Modules.Catalog.ProductCategories.Commands.Status.Disable;

public sealed class DisableProductCategoryCommand : IRequest<Unit>
{
    public required string Id { get; set; }
}

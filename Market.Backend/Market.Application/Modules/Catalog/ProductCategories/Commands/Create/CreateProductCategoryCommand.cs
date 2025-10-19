namespace Market.Application.Modules.Catalog.ProductCategories.Commands.Create;

public class CreateProductCategoryCommand : IRequest<string>
{
    public required string Name { get; set; }
}
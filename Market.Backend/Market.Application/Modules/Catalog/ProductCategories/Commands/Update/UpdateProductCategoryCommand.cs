namespace Market.Application.Modules.Catalog.ProductCategories.Commands.Update;

public sealed class UpdateProductCategoryCommand : IRequest<Unit>
{
    [JsonIgnore]
    public string Id { get; set; } = string.Empty;
    public required string Name { get; set; }
}

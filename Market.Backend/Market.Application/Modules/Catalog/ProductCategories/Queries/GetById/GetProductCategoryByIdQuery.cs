namespace Market.Application.Modules.Catalog.ProductCategories.Queries.GetById;

public class GetProductCategoryByIdQuery : IRequest<GetProductCategoryByIdQueryDto>
{
    public required string Id { get; set; }
}
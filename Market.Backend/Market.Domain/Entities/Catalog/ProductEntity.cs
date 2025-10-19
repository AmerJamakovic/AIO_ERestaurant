namespace Market.Domain.Entities.Catalog;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Market.Domain.Common;

public class ProductEntity : BaseEntity
{
    [Required]
    public required string Name { get; set; }

    public string? Description { get; set; }

    [Required]
    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public bool IsEnabled { get; set; } = true;

    // FK
    public required string CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public ProductCategoryEntity? Category { get; set; }
}

namespace Restaurant.Domain.Entities.Catalog;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Restaurant.Domain.Common;
using Restaurant.Domain.Entities.Misc;

public class Inventory : BaseEntity
{
    [Required]
    public required string IngredientId { get; set; }

    [ForeignKey("IngredientId")]
    public Ingredient? Ingredient { get; set; }

    [Required]
    public decimal QuantityInStock { get; set; }

    [Required]
    public string Unit { get; set; } = string.Empty;

    [Required]
    public decimal ReorderLevel { get; set; }

    [Required]
    public decimal ReorderQuantity { get; set; }

    public string? SupplierName { get; set; }

    public DateTime? LastRestocked { get; set; }
}

namespace Market.Domain.Entities.Catalog;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Market.Domain.Common;

public class MenuItemIngredient : BaseEntity
{
    [Required]
    public required string MenuItemId { get; set; }

    [ForeignKey("MenuItemId")]
    public MenuItem? MenuItem { get; set; }

    [Required]
    public required string IngredientId { get; set; }

    [ForeignKey("IngredientId")]
    public Ingredient? Ingredient { get; set; }
}

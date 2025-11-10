using Restaurant.Domain.Common;
using Restaurant.Domain.Entities.Misc;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Domain.Entities.Catalog;

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

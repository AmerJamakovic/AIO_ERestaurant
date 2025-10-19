namespace Market.Domain.Entities.Catalog;

using System.ComponentModel.DataAnnotations;
using Market.Domain.Common;

public class Ingredient : BaseEntity
{
    [Required]
    public required string Name { get; set; }
    public bool IsAllergen { get; set; } = false;
}

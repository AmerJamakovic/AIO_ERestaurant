namespace Restaurant.Domain.Entities.Misc;

using System.ComponentModel.DataAnnotations;
using Restaurant.Domain.Common;

public class Ingredient : BaseEntity
{
    [Required]
    public required string Name { get; set; }
    public AllergenTypeEnum AllergenType { get; set; } = AllergenTypeEnum.NONE;
}

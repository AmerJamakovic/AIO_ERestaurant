using Restaurant.Domain.Common;

using System.ComponentModel.DataAnnotations;

namespace Restaurant.Domain.Entities.Misc;

public class Ingredient : BaseEntity
{
    [Required]
    public required string Name { get; set; }
    public AllergenTypeEnum AllergenType { get; set; } = AllergenTypeEnum.NONE;
}

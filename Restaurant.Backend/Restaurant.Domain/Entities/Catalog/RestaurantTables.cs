namespace Restaurant.Domain.Entities.Catalog;

using System.ComponentModel.DataAnnotations;
using Restaurant.Domain.Common;

public class RestaurantTable : BaseEntity
{
    [Required]
    public required int Number { get; set; }

    [Required]
    public int NumberOfSets { get; set; }
    public bool IsAvailable { get; set; } = true;
} // Unfinished, will add more properties later

namespace Restaurant.Domain.Entities.Catalog;

using System.ComponentModel.DataAnnotations;
using Restaurant.Domain.Common;

public class RestaurantTable : BaseEntity
{
    [Required]
    public required int Number { get; set; }

    [Required]
    public required int NumberOfSeats { get; set; }

    public bool IsAvailable { get; set; }
}

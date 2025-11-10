using Restaurant.Domain.Common;

using System.ComponentModel.DataAnnotations;

namespace Restaurant.Domain.Entities.Catalog;

public class RestaurantTable : BaseEntity
{
    [Required]
    public required int Number { get; set; }

    [Required]
    public required int NumberOfSeats { get; set; }

    public bool IsAvailable { get; set; }
}

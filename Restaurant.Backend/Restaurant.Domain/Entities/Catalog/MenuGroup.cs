using System.ComponentModel.DataAnnotations;
using Restaurant.Domain.Common;

namespace Restaurant.Domain.Entities.Catalog;

public class MenuGroup : BaseEntity
{
    [Required]
    public required string Name { get; set; }

    public string? Description { get; set; }
}

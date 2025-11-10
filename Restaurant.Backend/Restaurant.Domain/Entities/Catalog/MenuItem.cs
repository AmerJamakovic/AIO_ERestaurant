using Restaurant.Domain.Common;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Domain.Entities.Catalog;

public class MenuItem : BaseEntity
{
    [Required]
    public required string Name { get; set; }

    public string? Description { get; set; }

    [Required]
    public required decimal Price { get; set; }

    public UInt32? Calories { get; set; }

    public string? ImageUrl { get; set; } // Consider using 'Image' class ??

    public bool IsAvailable { get; set; } = true;

    public bool IsActive { get; set; } = true;

    [Required]
    public required string MenuGroupId { get; set; }

    [ForeignKey("MenuGroupId")]
    public MenuGroup? MenuGroup { get; set; }
}

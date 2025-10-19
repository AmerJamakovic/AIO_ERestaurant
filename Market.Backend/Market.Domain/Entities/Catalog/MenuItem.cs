namespace Market.Domain.Entities.Catalog;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Market.Domain.Common;

public class MenuItem : BaseEntity
{
    [Required]
    public required string Name { get; set; }

    public string? Description { get; set; }

    [Required]
    public required decimal Price { get; set; }

    public int? Calories { get; set; }

    public bool IsSpecial { get; set; } = false;

    public string? ImageUrl { get; set; } // Image of some sort idk yet

    public bool IsAvailable { get; set; } = true;

    public bool IsActive { get; set; } = true;

    [Required]
    public required string GroupId { get; set; }

    [ForeignKey("GroupId")]
    public MenuGroup? Group { get; set; }
}

using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Domain.Entities.Misc;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Restaurant.Domain.Common;
using Restaurant.Domain.Entities.Identity;

public class Review : BaseEntity
{
    [Required]
    public required string CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public required Customer Customer { get; set; }

    public string? MenuItemId { get; set; }

    [ForeignKey("MenuItemId")]
    public MenuItem? MenuItem { get; set; }

    [Required]
    public int Rating { get; set; }
    public string? Comment { get; set; }
}

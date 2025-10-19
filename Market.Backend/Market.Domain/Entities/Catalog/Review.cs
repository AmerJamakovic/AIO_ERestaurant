namespace Market.Domain.Entities.Catalog;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Market.Domain.Common;
using Market.Domain.Entities.Identity;

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
    public bool IsApproved { get; set; } = false;
}

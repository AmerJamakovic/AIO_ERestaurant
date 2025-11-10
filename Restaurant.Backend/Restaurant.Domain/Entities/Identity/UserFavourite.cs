using Restaurant.Domain.Common;
using Restaurant.Domain.Entities.Catalog;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Domain.Entities.Identity;

public class UserFavorite : BaseEntity
{
    [Required]
    public required string CustomerId { get; set; }

    [Required]
    public required string MenuItemId { get; set; }

    [ForeignKey("CustomerId")]
    public required Customer Customer { get; set; }

    [ForeignKey("MenuItemId")]
    public required MenuItem MenuItem { get; set; }
}

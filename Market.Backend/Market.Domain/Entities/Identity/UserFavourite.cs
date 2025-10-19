namespace Market.Domain.Entities.Identity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Market.Domain.Common;
using Market.Domain.Entities.Catalog;

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

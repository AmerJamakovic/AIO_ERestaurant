namespace Market.Domain.Entities.Identity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Market.Domain.Common;
using Market.Domain.Entities.Catalog;

public class UserFavorite : BaseEntity
{
    [Required]
    public required string UserId { get; set; }

    [Required]
    public required string MenuItemId { get; set; }

    [ForeignKey("UserId")]
    public required User User { get; set; }

    [ForeignKey("MenuItemId")]
    public required MenuItem MenuItem { get; set; }
}

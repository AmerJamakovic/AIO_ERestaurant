using System.ComponentModel.DataAnnotations;
using Market.Domain.Common;

namespace Market.Domain.Entities.Catalog;

public class MenuGroup : BaseEntity
{
    [Required]
    public required string Name { get; set; }
    public string? Description { get; set; }
}

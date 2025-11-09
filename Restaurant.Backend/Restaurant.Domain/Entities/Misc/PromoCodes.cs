namespace Restaurant.Domain.Entities.Misc;

using System.ComponentModel.DataAnnotations;
using Restaurant.Domain.Common;

public class PromoCode : BaseEntity
{
    [Required]
    public required string Code { get; set; }

    [Required]
    public required float Discount { get; set; }

    public required DateTime ValidFrom { get; set; }

    public required DateTime ValidUntil { get; set; }

    public bool IsActive { get; set; }

    public UInt32? MaxUses { get; set; }
}

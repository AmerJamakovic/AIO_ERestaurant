namespace Restaurant.Domain.Entities.Catalog;

using System.ComponentModel.DataAnnotations;
using Restaurant.Domain.Common;

public class PromoCode : BaseEntity
{
    [Required]
    public required string Code { get; set; }

    [Required]
    public DiscountTypeEnum DiscountType { get; set; }

    [Required]
    public decimal Value { get; set; }

    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidUntil { get; set; }
    public bool IsActive { get; set; } = true;
    public int? MaxUses { get; set; }
}

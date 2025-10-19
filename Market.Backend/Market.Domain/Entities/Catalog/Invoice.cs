namespace Market.Domain.Entities.Catalog;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Market.Domain.Common;

public class Invoice : BaseEntity
{
    [Required]
    public required string OrderId { get; set; }

    [ForeignKey("OrderId")]
    public Order? Order { get; set; }

    [Required]
    public decimal TotalAmount { get; set; }

    [Required]
    public PaymentMethodEnum PaymentMethod { get; set; }

    [Required]
    public PaymentStatusEnum PaymentStatus { get; set; } = PaymentStatusEnum.PENDING;

    public string? PromoCodeId { get; set; }

    [ForeignKey("PromoCodeId")]
    public PromoCode? PromoCode { get; set; }

    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
}

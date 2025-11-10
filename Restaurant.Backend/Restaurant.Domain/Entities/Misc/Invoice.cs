using Restaurant.Domain.Common;
using Restaurant.Domain.Entities.PaymentProcessing;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Domain.Entities.Misc;

public class Invoice : BaseEntity
{
    [Required]
    public required string OrderId { get; set; }

    [ForeignKey("OrderId")]
    public Order? Order { get; set; }

    [Required]
    public required decimal TotalAmount { get; set; }

    [Required]
    public required PaymentMethodEnum PaymentMethod { get; set; }

    [Required]
    public PaymentStatusEnum PaymentStatus { get; set; }

    public required DateTime PaymentDate { get; set; }
}

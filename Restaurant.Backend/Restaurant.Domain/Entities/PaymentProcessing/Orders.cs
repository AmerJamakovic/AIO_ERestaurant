using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Domain.Entities.PaymentProcessing;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Restaurant.Domain.Common;
using Restaurant.Domain.Entities.Identity;
using Restaurant.Domain.Entities.Misc;

public class Order : BaseEntity
{
    public string? CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public Customer? Customer { get; set; }

    public string? EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    public Employee? Employee { get; set; }

    public string? TableId { get; set; }

    [ForeignKey("TableId")]
    public RestaurantTable? Table { get; set; }

    [Required]
    public required OrderTypeEnum OrderType { get; set; } // TODO: Create validation based on order source (enum)

    [Required]
    public required OrderStatusEnum OrderStatus { get; set; }

    public string? PromoCodeId { get; set; }

    [ForeignKey("PromoCodeId")]
    public PromoCode? PromoCode { get; set; }
}

using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Domain.Entities.PaymentProcessing;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Restaurant.Domain.Common;

public class OrderItem : BaseEntity
{
    [Required]
    public required string OrderId { get; set; }

    [ForeignKey("OrderId")]
    public Order? Order { get; set; }

    [Required]
    public required string MenuItemId { get; set; }

    [ForeignKey("MenuItemId")]
    public MenuItem? MenuItem { get; set; }

    [Required]
    public required int Quantity { get; set; }

    [Required]
    public required decimal UnitPrice { get; set; }
}

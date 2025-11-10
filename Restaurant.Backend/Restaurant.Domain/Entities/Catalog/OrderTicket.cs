using Restaurant.Domain.Common;
using Restaurant.Domain.Entities.PaymentProcessing;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Domain.Entities.Catalog;

public class OrderTicket : BaseEntity
{
    [Required]
    public required string OrderItemId { get; set; }

    [ForeignKey("OrderItemId")]
    public required OrderItem OrderItem { get; set; }

    [Required]
    public required TicketDestinationEnum Destination { get; set; }

    [Required]
    public required TicketStatusEnum Status { get; set; }

    public string? Notes { get; set; }
}

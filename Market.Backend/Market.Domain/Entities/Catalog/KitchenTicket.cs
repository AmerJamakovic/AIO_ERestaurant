namespace Market.Domain.Entities.Catalog;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Market.Domain.Common;

public class KitchenTicket : BaseEntity
{
    [Required]
    public required string OrderItemId { get; set; }

    [ForeignKey("OrderItemId")]
    public required OrderItem OrderItem { get; set; }

    [Required]
    public TicketDestinationEnum Destination { get; set; }

    [Required]
    public TicketStatusEnum Status { get; set; } = TicketStatusEnum.SENT;

    public string? Notes { get; set; }
}

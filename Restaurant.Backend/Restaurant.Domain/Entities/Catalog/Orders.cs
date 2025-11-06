namespace Restaurant.Domain.Entities.Catalog;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Restaurant.Domain.Common;
using Restaurant.Domain.Entities.Identity;

public class Order : BaseEntity
{
    [ForeignKey("CustomerId")]
    public string? CustomerId { get; set; }
    public Customer? Customer { get; set; }

    [ForeignKey("EmployeeId")]
    public string? EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    [ForeignKey("TableId")]
    public string? TableId { get; set; }
    public RestaurantTable? Table { get; set; }

    [Required]
    public OrderSourceEnum OrderSource { get; set; } = OrderSourceEnum.DINE_IN; // TODO: Create validation based on order source (enum)

    [Required]
    public OrderTypeEnum OrderType { get; set; }

    [Required]
    public OrderStatusEnum OrderStatus { get; set; } = OrderStatusEnum.OPEN;

    public string? DeliveryAddress { get; set; }
    public string? Notes { get; set; }
}

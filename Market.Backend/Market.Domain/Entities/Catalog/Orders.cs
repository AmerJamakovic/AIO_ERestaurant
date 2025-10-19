namespace Market.Domain.Entities.Catalog;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Market.Domain.Common;
using Market.Domain.Entities.Identity;

public class Order : BaseEntity
{
    public string? CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public User? Customer { get; set; }

    public string? EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    public Employee? Employee { get; set; }

    public string? TableId { get; set; }

    [ForeignKey("TableId")]
    public RestaurantTable? Table { get; set; }

    [Required]
    public OrderTypeEnum OrderType { get; set; }

    [Required]
    public OrderStatusEnum OrderStatus { get; set; } = OrderStatusEnum.OPEN;

    public string? DeliveryAddress { get; set; }
    public string? Notes { get; set; }
}

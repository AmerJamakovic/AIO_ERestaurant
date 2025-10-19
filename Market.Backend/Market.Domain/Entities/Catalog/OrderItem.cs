namespace Market.Domain.Entities.Catalog;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Market.Domain.Common;

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
    public int Quantity { get; set; } = 1;

    [Required]
    public decimal UnitPriceAtOrder { get; set; }

    public string? SpecialInstructions { get; set; }
}

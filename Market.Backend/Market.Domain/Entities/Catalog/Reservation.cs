namespace Market.Domain.Entities.Catalog;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Market.Domain.Common;
using Market.Domain.Entities.Identity;

public class Reservation : BaseEntity
{
    [Required]
    public required string CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public required Customer Customer { get; set; }

    [Required]
    public required string TableId { get; set; }

    [ForeignKey("TableId"), Required]
    public required RestaurantTable Table { get; set; }

    [Required]
    public DateTime ReservationDate { get; set; }

    [Required]
    public int PartySize { get; set; }

    public string? SpecialRequests { get; set; }

    [Required]
    public ReservationStatusEnum Status { get; set; } = ReservationStatusEnum.PENDING;
}

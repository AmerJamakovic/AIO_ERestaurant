using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Domain.Entities.PaymentProcessing;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Restaurant.Domain.Common;
using Restaurant.Domain.Entities.Identity;

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
    public required DateTime ReservationDate { get; set; }

    [Required]
    public required int PartySize { get; set; }

    [Required]
    public ReservationStatusEnum Status { get; set; } = ReservationStatusEnum.PENDING;
}

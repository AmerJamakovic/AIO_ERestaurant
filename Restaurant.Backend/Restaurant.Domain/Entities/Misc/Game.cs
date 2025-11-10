using Restaurant.Domain.Common;

namespace Restaurant.Domain.Entities.Misc;

public class Game : BaseEntity
{
    public required string Name { get; set; }
    public required UInt16 PlaceWon { get; set; }
    public required DateTime DateHeld { get; set; }
    public required string Category { get; set; }
    public string? Description { get; set; }
}

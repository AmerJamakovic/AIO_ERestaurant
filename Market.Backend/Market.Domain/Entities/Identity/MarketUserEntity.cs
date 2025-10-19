namespace Market.Domain.Entities.Identity;

using System.ComponentModel.DataAnnotations;
using Market.Domain.Common;

public class MarketUserEntity : BaseEntity
{
    [Required]
    public required string Email { get; set; }

    [Required]
    public required string PasswordHash { get; set; }

    public bool IsAdmin { get; set; }
    public bool IsEmployee { get; set; }
    public bool IsManager { get; set; }
    public bool IsEnabled { get; set; } = true;

    public int TokenVersion { get; set; }

    // Navigation
    public ICollection<RefreshTokenEntity> RefreshTokens { get; set; } = new List<RefreshTokenEntity>();
}

namespace Market.Domain.Entities.Identity;

using System.ComponentModel.DataAnnotations;
using Market.Domain.Common;

public class User : BaseEntity
{
    [Required]
    public required string FirstName { get; set; }

    [Required]
    public required string LastName { get; set; }

    [Required, EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string PasswordHash { get; set; }

    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public bool IsVerified { get; set; } = false;
    public bool IsActive { get; set; } = true;
    // Backwards-compatible flag expected by Application
    public bool IsEnabled { get; set; } = true;

    // Flags to mirror older MarketUserEntity shape (keeps JwtTokenService and other code working)
    public bool IsAdmin { get; set; }
    public bool IsEmployee { get; set; }
    public bool IsManager { get; set; }

    // Token rotation/versioning used by JwtTokenService
    public int TokenVersion { get; set; }

    [Required]
    public RoleEnum Role { get; set; } = RoleEnum.CUSTOMER;
}

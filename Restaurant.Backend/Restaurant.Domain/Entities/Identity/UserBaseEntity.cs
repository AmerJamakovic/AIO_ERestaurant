using Restaurant.Domain.Common;

using System.ComponentModel.DataAnnotations;

namespace Restaurant.Domain.Entities.Identity;

public abstract class UserBaseEntity : BaseEntity
{
    [Required]
    public required string FirstName { get; set; }

    [Required]
    public required string LastName { get; set; }

    [Required, EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string PasswordHash { get; set; }

    public bool IsVerified { get; set; } = true;
    public int TokenVersion { get; set; }

    [Required]
    public RoleEnum Role { get; set; } = RoleEnum.NOT_ASSIGNED;
}

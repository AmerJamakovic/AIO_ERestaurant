namespace Market.Domain.Entities.Identity;

using System.ComponentModel.DataAnnotations;
using Market.Domain.Common;

public class UserBaseEntity : BaseEntity
{
    [Required]
    public required string FirstName { get; set; }

    [Required]
    public required string LastName { get; set; }

    [Required, EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string PasswordHash { get; set; }

    public bool IsVerified { get; set; } = false;
    public int TokenVersion { get; set; }

    [Required]
    public RoleEnum Role { get; set; } = RoleEnum.NOT_ASSIGNED;
}

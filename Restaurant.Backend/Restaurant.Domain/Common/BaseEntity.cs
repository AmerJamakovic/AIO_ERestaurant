using System.ComponentModel.DataAnnotations;

namespace Restaurant.Domain.Common;

public abstract class BaseEntity
{
    [Key]
    [StringLength(26)]
    public string Id { get; set; } = Ulid.NewUlid().ToString();

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    [Required]
    public bool IsDeleted { get; set; } = false;

    public void SoftDelete()
    {
        IsDeleted = true;
        DeletedAt = DateTime.UtcNow;
    }
}

namespace Restaurant.Domain.Common;

using System.ComponentModel.DataAnnotations;
using static Ulid;

public abstract class BaseEntity
{
    [Key]
    [StringLength(26)]
    public string Id { get; set; } = NewUlid().ToString();

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

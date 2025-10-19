namespace Market.Domain.Entities.Identity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Market.Domain.Common;

public class Employee : BaseEntity
{
    [Required]
    public required string UserId { get; set; }

    [ForeignKey("UserId")]
    public User? User { get; set; }

    [Required]
    public JobTitleEnum JobTitle { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? HireDate { get; set; }
    public int YearsOfExperience { get; set; } = 0;
}

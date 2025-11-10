using Restaurant.Domain.Common;

using System.ComponentModel.DataAnnotations;

namespace Restaurant.Domain.Entities.Identity;

public class Employee : UserBaseEntity
{
    [Required]
    public JobTitleEnum JobTitle { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? HireDate { get; set; }
    public int YearsOfExperience { get; set; } = 0;
}

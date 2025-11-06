namespace Restaurant.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using Restaurant.Domain.Common;

public class Employee : UserBaseEntity
{
    [Required]
    public JobTitleEnum JobTitle { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? HireDate { get; set; }
    public int YearsOfExperience { get; set; } = 0;
}

namespace Market.Domain.Entities.Identity;

public class Customer : UserBaseEntity
{
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public bool IsActive { get; set; } = true;
}

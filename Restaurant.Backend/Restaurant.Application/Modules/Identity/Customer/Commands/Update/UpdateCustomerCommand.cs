using Restaurant.Shared.Dtos.Identity;
using System.Text.Json.Serialization;

namespace Restaurant.Application.Modules.Identity.Customer.Commands.Update;

public class UpdateCustomerCommand : IRequest<UpdateCustomerDto>
{
    [JsonIgnore]
    public string Id { get; set; } = string.Empty;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    //public required string Password { get; set; }  Will be added in the future updates
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public bool? IsActive { get; set; }
}

using Restaurant.Shared.Dtos.Identity;

namespace Restaurant.Application.Modules.Identity.Customer.Commands.Delete;

public class DeleteCustomerCommand : IRequest<DeleteCustomerDto>
{
    public string Id { get; set; } = string.Empty;
}

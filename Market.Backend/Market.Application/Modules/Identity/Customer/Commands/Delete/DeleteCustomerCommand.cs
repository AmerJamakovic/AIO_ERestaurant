using Market.Shared.Dtos.Identity;

namespace Market.Application.Modules.Identity.Customer.Commands.Delete
{
    public class DeleteCustomerCommand : IRequest<DeleteCustomerDto>
    {
        public string Id { get; set; }
    }
}

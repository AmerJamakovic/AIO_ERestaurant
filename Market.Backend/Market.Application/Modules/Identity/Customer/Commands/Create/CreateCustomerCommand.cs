using Market.Shared.Dtos.Identity;

namespace Market.Application.Modules.Identity.Customer.Commands.Create
{
    public class CreateCustomerCommand : IRequest<CustomerDto>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }
    }
}

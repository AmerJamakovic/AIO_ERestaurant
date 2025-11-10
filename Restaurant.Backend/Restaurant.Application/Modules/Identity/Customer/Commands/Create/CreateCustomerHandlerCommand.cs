using Restaurant.Domain.Common;
using Restaurant.Shared.Dtos.Identity;

namespace Restaurant.Application.Modules.Identity.Customer.Commands.Create;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerDto>
{
    private readonly IAppDbContext _context;
    private readonly IPasswordHasher<Domain.Entities.Identity.Customer> _passwordHasher;

    public CreateCustomerCommandHandler(
        IAppDbContext context,
        IPasswordHasher<Domain.Entities.Identity.Customer> passwordHasher
    )
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    public async Task<CreateCustomerDto> Handle(
        CreateCustomerCommand request,
        CancellationToken cancellationToken
    )
    {
        // Check if email is already taken
        var emailExists = await _context.Customers.AnyAsync(
            x => x.Email == request.Email,
            cancellationToken
        );

        if (emailExists)
        {
            throw new ValidationException("Email is already taken");
        }

        var customer = new Domain.Entities.Identity.Customer
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PasswordHash = request.Password, // Temporary - will be hashed after creation
            PhoneNumber = request.PhoneNumber,
            Address = request.Address,
            Role = RoleEnum.CUSTOMER,
            IsVerified = true,
        };

        _context.Customers.Add(customer);
        // Need to check if PasswordHash is updated in DB after hashing provided password in 58 line

        // Hash the password after creating customer
        customer.PasswordHash = _passwordHasher.HashPassword(customer, request.Password);

        await _context.SaveChangesAsync(cancellationToken);

        return new CreateCustomerDto
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            Address = customer.Address,
            PhoneNumber = customer.PhoneNumber,
            Password = customer.PasswordHash
        };
    }
}

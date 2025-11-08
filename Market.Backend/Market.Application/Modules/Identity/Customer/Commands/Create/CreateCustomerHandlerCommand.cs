namespace Market.Application.Modules.Identity.Customer.Commands.Create;

using Market.Domain.Common;
using Market.Domain.Entities.Identity;
using Market.Shared.Dtos.Identity;
using Microsoft.EntityFrameworkCore;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
{
    private readonly IAppDbContext _context;
    private readonly IPasswordHasher<Customer> _passwordHasher;
    private readonly IMapper _mapper;

    public CreateCustomerCommandHandler(
        IAppDbContext context,
        IPasswordHasher<Customer> passwordHasher,
        IMapper mapper
    )
    {
        _context = context;
        _passwordHasher = passwordHasher;
        _mapper = mapper;
    }

    public async Task<CustomerDto> Handle(
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

        var customer = new Customer
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

        return _mapper.Map<CustomerDto>(customer);
    }
}

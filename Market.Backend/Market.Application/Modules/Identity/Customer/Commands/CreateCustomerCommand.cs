namespace Market.Application.Modules.Identity.Customer.Commands;

using Market.Domain.Common;
using Market.Domain.Entities.Identity;
using Market.Shared.Dtos.Identity;
using Microsoft.EntityFrameworkCore;

public record CreateCustomerCommand(CreateCustomerDto Dto) : IRequest<CustomerDto>;

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
            x => x.Email == request.Dto.Email,
            cancellationToken
        );

        if (emailExists)
        {
            throw new ValidationException("Email is already taken");
        }

        var customer = new Customer
        {
            FirstName = request.Dto.FirstName,
            LastName = request.Dto.LastName,
            Email = request.Dto.Email,
            PasswordHash = request.Dto.Password, // Temporary - will be hashed after creation
            PhoneNumber = request.Dto.PhoneNumber,
            Address = request.Dto.Address,
            Role = RoleEnum.CUSTOMER,
            IsVerified = true,
        };

        _context.Customers.Add(customer);

        // Hash the password after creating customer
        customer.PasswordHash = _passwordHasher.HashPassword(customer, request.Dto.Password);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CustomerDto>(customer);
    }
}

using Restaurant.Domain.Common;
using ValidationException = FluentValidation.ValidationException;

namespace Restaurant.Application.Modules.Identity.Users.Commands;

public class RegisterUserHandlerCommand : IRequestHandler<RegisterUserCommand, JwtTokenPair>
{
    private readonly IAppDbContext _db;
    private readonly IJwtTokenService _jwtService;
    private readonly IPasswordHasher<Customer> _passwordHasher;

    public RegisterUserHandlerCommand(
        IAppDbContext db,
        IJwtTokenService jwtService,
        IPasswordHasher<Customer> passwordHasher
    )
    {
        _db = db;
        _jwtService = jwtService;
        _passwordHasher = passwordHasher;
    }

    public async Task<JwtTokenPair> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken
    )
    {
        // Check if email exists
        var emailExists = await _db.Customers.AnyAsync(
            u => u.Email == request.Email,
            cancellationToken
        );

        if (emailExists)
        {
            throw new ValidationException("Email is already taken");
        }

        var customer = new Customer
        {
            FirstName = request.Username, // Consider updating DTO to include FirstName/LastName
            LastName = "", // Consider updating DTO to include FirstName/LastName
            Email = request.Email,
            PasswordHash = request.Password, // We'll hash it after customer creation
            Role = RoleEnum.CUSTOMER,
            IsVerified = true,
        };

        _db.Customers.Add(customer);

        // Hash password after creating the customer instance
        customer.PasswordHash = _passwordHasher.HashPassword(customer, request.Password);

        await _db.SaveChangesAsync(cancellationToken);

        return _jwtService.IssueTokens(customer);
    }
}

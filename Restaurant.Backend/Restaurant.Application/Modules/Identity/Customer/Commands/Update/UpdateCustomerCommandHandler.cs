using Restaurant.Shared.Dtos.Identity;

namespace Restaurant.Application.Modules.Identity.Customer.Commands.Update;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerDto>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public UpdateCustomerCommandHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UpdateCustomerDto> Handle(
        UpdateCustomerCommand request,
        CancellationToken cancellationToken
    )
    {
        if (string.IsNullOrWhiteSpace(request.Id))
             throw new NotFoundException("Invalid input");

        var customer =
        await _context.Customers.FirstOrDefaultAsync(
            x => x.Id == request.Id && !x.IsDeleted,
            cancellationToken
        ) ?? throw new NotFoundException($"Customer with ID {request.Id} was not found");

        // Update only provided fields
        if (string.IsNullOrEmpty(request.FirstName))
            customer.FirstName = request.FirstName!;
        if (string.IsNullOrEmpty(request.LastName))
            customer.LastName = request.LastName!;
        if (string.IsNullOrEmpty(request.PhoneNumber))
            customer.PhoneNumber = request.PhoneNumber;
        if (string.IsNullOrEmpty(request.Address))
            customer.Address = request.Address;
        if (request.IsActive.HasValue)
            customer.IsActive = request.IsActive.Value;

        customer.UpdatedAt = DateTime.UtcNow;
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateCustomerDto
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.PhoneNumber,
            Address = customer.Address,
            IsActive = customer.IsActive
        };
    }
}

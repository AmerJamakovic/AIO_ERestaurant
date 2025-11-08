namespace Market.Application.Modules.Identity.Customer.Commands.Update;
using Market.Application.Common.Exceptions;
using Market.Shared.Dtos.Identity;
using Microsoft.EntityFrameworkCore;

public record UpdateCustomerCommand(string Id, UpdateCustomerDto Dto) : IRequest<CustomerDto>;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerDto>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public UpdateCustomerCommandHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CustomerDto> Handle(
        UpdateCustomerCommand request,
        CancellationToken cancellationToken
    )
    {
        // Should add some logic for checking if the provided ID in invalid format (empty, null, etc)
        // therefore in that case no need to run query
        // For example
        // if (string.IsNullOrWhiteSpace(request.Id))
        //      throw new NotFoundException("Invalid input");

        var customer =
        await _context.Customers.FirstOrDefaultAsync(
            x => x.Id == request.Id && !x.IsDeleted,
            cancellationToken
        ) ?? throw new NotFoundException($"Customer with ID {request.Id} was not found");

        // Update only provided fields
        if (request.Dto.FirstName != null) // Maybe choose string.IsNullOrEmpty() method instead of current not null if condition
            customer.FirstName = request.Dto.FirstName;
        if (request.Dto.LastName != null)
            customer.LastName = request.Dto.LastName;
        if (request.Dto.PhoneNumber != null)
            customer.PhoneNumber = request.Dto.PhoneNumber;
        if (request.Dto.Address != null)
            customer.Address = request.Dto.Address;
        if (request.Dto.IsActive.HasValue)
            customer.IsActive = request.Dto.IsActive.Value;

        customer.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CustomerDto>(customer);
    }
}

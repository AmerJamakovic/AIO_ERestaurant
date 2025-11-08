namespace Market.Application.Modules.Identity.Customer.Commands.Delete;
using Market.Application.Common.Exceptions;
using Market.Shared.Dtos.Identity;
using Microsoft.EntityFrameworkCore;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerDto>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public DeleteCustomerCommandHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<DeleteCustomerDto> Handle(
        DeleteCustomerCommand request,
        CancellationToken cancellationToken
    )
    {
        // Should add some logic for checking if provided ID is valid, if its not the case then no need to run query 

        var customer =
            await _context.Customers.FirstOrDefaultAsync(
                x => x.Id == request.Id && !x.IsDeleted,
                cancellationToken
            ) ?? throw new NotFoundException($"Customer with ID {request.Id} was not found");

        customer.SoftDelete();
        await _context.SaveChangesAsync(cancellationToken);

        return new DeleteCustomerDto
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Password = customer.PasswordHash,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
        };
    }
}

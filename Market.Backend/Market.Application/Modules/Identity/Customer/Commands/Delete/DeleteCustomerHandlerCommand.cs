namespace Market.Application.Modules.Identity.Customer.Commands.Delete;

using Market.Application.Common.Exceptions;
using Market.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

public record DeleteCustomerHandlerCommand(string Id) : IRequest<bool>;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerHandlerCommand, bool>
{
    private readonly IAppDbContext _context;

    public DeleteCustomerCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(
        DeleteCustomerHandlerCommand request,
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

        return true;
    }
}

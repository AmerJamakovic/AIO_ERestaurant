namespace Market.Application.Modules.Identity.Customer.Commands;

using Market.Application.Common.Exceptions;
using Market.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

public record DeleteCustomerCommand(string Id) : IRequest<bool>;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
{
    private readonly IAppDbContext _context;

    public DeleteCustomerCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(
        DeleteCustomerCommand request,
        CancellationToken cancellationToken
    )
    {
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

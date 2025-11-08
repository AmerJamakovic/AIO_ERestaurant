namespace Market.Application.Modules.Identity.Customer.Queries;
using Market.Application.Common.Exceptions;
using Market.Shared.Dtos.Identity;
using Microsoft.EntityFrameworkCore;

public record GetCustomerByIdQuery(string Id) : IRequest<CustomerDto>;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetCustomerByIdQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CustomerDto> Handle(
        GetCustomerByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        var customer =
            await _context.Customers.FirstOrDefaultAsync(
                x => x.Id == request.Id && !x.IsDeleted,
                cancellationToken
            ) ?? throw new NotFoundException($"Customer with ID {request.Id} was not found");

        return _mapper.Map<CustomerDto>(customer);
    }
}

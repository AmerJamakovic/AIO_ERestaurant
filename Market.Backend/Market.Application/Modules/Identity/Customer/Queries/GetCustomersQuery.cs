namespace Market.Application.Modules.Identity.Customer.Queries;

using Market.Application.Common;
using Market.Domain.Entities.Identity;
using Market.Shared.Dtos.Identity;
using Microsoft.EntityFrameworkCore;

public sealed class GetCustomersQuery : BasePagedQuery<CustomerDto>
{
    public GetCustomersQuery(PageRequest pageRequest)
    {
        Paging = pageRequest;
    }
}

public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, PageResult<CustomerDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetCustomersQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PageResult<CustomerDto>> Handle(
        GetCustomersQuery request,
        CancellationToken cancellationToken
    )
    {
        var query = _context.Customers.Where(x => !x.IsDeleted).OrderByDescending(x => x.CreatedAt);

        if (!string.IsNullOrEmpty(request.Paging.SearchTerm))
        {
            var searchTerm = request.Paging.SearchTerm.ToLower();
            query =
                (IOrderedQueryable<Customer>)
                    query.Where(x =>
                        x.FirstName.ToLower().Contains(searchTerm)
                        || x.LastName.ToLower().Contains(searchTerm)
                        || x.Email.ToLower().Contains(searchTerm)
                        || (x.PhoneNumber != null && x.PhoneNumber.ToLower().Contains(searchTerm))
                        || (x.Address != null && x.Address.ToLower().Contains(searchTerm))
                    );
        }

        return await PageResult<CustomerDto>.FromQueryableAsync(
            query.Select(x => _mapper.Map<CustomerDto>(x)),
            request.Paging,
            cancellationToken
        );
    }
}
